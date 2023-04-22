using CouchBotOSS.Dalton.Models;
using Microsoft.Extensions.Options;
using MTD.CouchBot.Accessors.Contracts;

namespace CouchBotOSS.Dalton.Services.Hosted
{
    public class PatreonWorker : BackgroundService
    {
        private readonly IPatreonAccessor _patreonAccessor;
        private readonly ILogger<PatreonWorker> _logger;
        private readonly TimerConfiguration _timerConfiguration;

        public PatreonWorker(ILogger<PatreonWorker> logger,
            IOptions<TimerConfiguration> timerConfiguration,
            IPatreonAccessor patreonAccessor)
        {
            _logger = logger;
            _timerConfiguration = timerConfiguration.Value;
            _patreonAccessor = patreonAccessor;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var patronList = await _patreonAccessor.ListAsync(cancellationToken);

                // We'll eventually do stuff here!
                
                await Task.Delay(TimeSpan.FromMilliseconds(_timerConfiguration.PatreonQueryIntervalMs),
                    cancellationToken);
            }
        }
    }
}