using CouchBotOSS.Bot.Services.Bot;
using Discord.WebSocket;
using MTD.CouchBot.Services;

namespace CouchBotOSS.Bot.Services.Hosted
{
    public class BotService : IHostedService
    {
        private readonly DiscordSocketClient _discordSocketClient;
        private readonly GuildInteractionService _guildInteractionService;
        private readonly MessageInteractionService _messageInteractionService;
        private readonly StartupService _startupService;
        private readonly BotCommandService _commandService;
        private readonly ILogger<BotService> _logger;

        public BotService(ILogger<BotService> logger, 
            DiscordSocketClient discordSocketClient, 
            GuildInteractionService guildInteractionService, 
            MessageInteractionService messageInteractionService, 
            StartupService startupService, 
            BotCommandService commandService)
        {
            _logger = logger;
            _discordSocketClient = discordSocketClient;
            _guildInteractionService = guildInteractionService;
            _messageInteractionService = messageInteractionService;
            _startupService = startupService;
            _commandService = commandService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _startupService.StartAsync();

            while (_discordSocketClient.CurrentUser == null)
            {
                _logger.LogInformation("Discord user connection pending ...");
                await Task.Delay(5000, cancellationToken);
            }

            _logger.LogInformation($"Discord user connected: {_discordSocketClient.CurrentUser.Username}");

            _commandService.Init();
            _guildInteractionService.Init();
            _messageInteractionService.Init();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Bot stopping");

            return Task.CompletedTask;
        }
    }
}
