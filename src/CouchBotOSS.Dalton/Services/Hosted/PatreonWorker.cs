using CouchBotOSS.Accessors.Contracts;
using CouchBotOSS.Dalton.Models;
using CouchBotOSS.Shared.Enums;
using Microsoft.Extensions.Options;

namespace CouchBotOSS.Dalton.Services.Hosted
{
    public class PatreonWorker : BackgroundService
    {
        private readonly IDiscordUserAccessor _discordUserAccessor;
        private readonly ILogger<PatreonWorker> _logger;
        private readonly IPatreonAccessor _patreonAccessor;
        private readonly TimerConfiguration _timerConfiguration;

        public PatreonWorker(ILogger<PatreonWorker> logger,
            IOptions<TimerConfiguration> timerConfiguration,
            IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _timerConfiguration = timerConfiguration.Value;

            var scope = serviceScopeFactory.CreateScope();
            _patreonAccessor = scope.ServiceProvider.GetRequiredService<IPatreonAccessor>();
            _discordUserAccessor = scope.ServiceProvider.GetRequiredService<IDiscordUserAccessor>();
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                // Get the list of all Patrons.
                var patronList = await _patreonAccessor.ListAsync(cancellationToken);

                // Parse out the list of only active / complete Patrons.
                var activePatronList = patronList.Data.Where(
                    x => !string.IsNullOrEmpty(x.Attributes.PatronStatus) &&
                                                                  x.Attributes.PatronStatus.Equals("active_patron") &&
                                                                  x.Relationships.currently_entitled_tiers.Data.Count > 0 &&
                                                                  !x.Relationships.currently_entitled_tiers.Data.Any(y => string.IsNullOrEmpty(y.Id))).ToList();

                // Get the list of DiscordUsers in the CouchBot Database.
                var discordUsers = await _discordUserAccessor.ListAsync();

                // Process the patrons
                foreach (var patron in activePatronList)
                {
                    // Get the current Patron with an associated Discord UserId.
                    var patreonDiscordUser = patronList.Included.FirstOrDefault(x => x.Id == patron.Relationships.user.Data.Id);

                    // If the Discord Id is not connected, we'll skip processing this patron.
                    if (string.IsNullOrEmpty(patreonDiscordUser?.Attributes?.SocialConnections?.Discord?.user_id))
                    {
                        _logger.LogInformation("There was an issue getting the Discord account for Patron {FirstName} {LastName}, ID: {Id}",
                            patreonDiscordUser.Attributes.FirstName,
                            patreonDiscordUser.Attributes.LastName,
                            patreonDiscordUser.Id);

                        continue;
                    }

                    // Get the user record, if it exists, from the list of CouchBot stored Discord Users.
                    var couchDiscordUser = discordUsers.FirstOrDefault(x =>
                        x.DiscordUserId == patreonDiscordUser.Attributes.SocialConnections.Discord.user_id);

                    // If this is null, move on to the next patron.
                    if (couchDiscordUser == null)
                    {
                        _logger.LogInformation("There was an issue getting the CouchBot Discord User Account for Patron {FirstName} {LastName}, ID: {Id}, DiscordUserId: {DiscordUserId}",
                            patreonDiscordUser.Attributes.FirstName,
                            patreonDiscordUser.Attributes.LastName,
                            patreonDiscordUser.Id,
                            patreonDiscordUser.Attributes.SocialConnections.Discord.user_id);

                        continue;
                    }

                    // Determine the allowance, based off the currently entitled tier.
                    var allowance =
                        int.Parse(patron.Relationships.currently_entitled_tiers.Data.FirstOrDefault()?.Id) switch
                        {
                            (int)PatreonTiers.Recliner => 2,
                            (int)PatreonTiers.Loveseat => 1,
                            (int)PatreonTiers.Couch => 3,
                            (int)PatreonTiers.KindaFancyCouch => 5,
                            (int)PatreonTiers.FancyCouch => 8,
                            _ => 0
                        };

                    // If our current allowance matches the existing allowance, move on to the next patron.
                    if (couchDiscordUser.Allowance == allowance)
                    {
                        continue;
                    }

                    // Update the allowance for the CouchBot stored Discord User.
                    couchDiscordUser.Allowance = allowance;
                    await _discordUserAccessor.UpdateAsync(couchDiscordUser);

                    _logger.LogInformation("Updated {DiscordUser} to {Allowance} server allowance.",
                        couchDiscordUser.DiscordUserId,
                        allowance);
                }

                await Task.Delay(TimeSpan.FromMilliseconds(_timerConfiguration.PatreonQueryIntervalMs),
                    cancellationToken);
            }
        }
    }
}