using System.Reflection;
using CouchBotOSS.Shared.Models;
using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Options;

namespace MTD.CouchBot.Services;

public class StartupService
{
    private readonly DiscordSocketClient _discordSocketClient;
    private readonly TokenConfiguration _tokens;
    private readonly IServiceProvider _serviceProvider;
    private readonly InteractionService _interactionService;
    private readonly CommandService _commandService;
    private readonly ILogger<StartupService> _logger;

    public StartupService(
        DiscordSocketClient discordSocketClient,
        IOptions<TokenConfiguration> tokens,
        IServiceProvider serviceProvider,
        InteractionService interactionService,
        ILogger<StartupService> logger,
        CommandService commandService)
    {
        _tokens = tokens.Value;
        _discordSocketClient = discordSocketClient;
        _serviceProvider = serviceProvider;
        _interactionService = interactionService;
        _logger = logger;
        _commandService = commandService;
    }

    public async Task StartAsync()
    {
        _logger.LogInformation("Starting connection to Discord ...");
        var discordToken = _tokens.Discord;

        if (string.IsNullOrWhiteSpace(discordToken))
        {
            _logger.LogCritical("Bot token missing from the `appsettings.json` file. Please enter the bot token, and restart the service.");

            throw new Exception("Please enter your bot's token into the `appsettings.json` file found in the applications root directory.");
        }

        await _discordSocketClient.LoginAsync(TokenType.Bot, discordToken);
        await _discordSocketClient.StartAsync();

        await _interactionService.AddModulesAsync(Assembly.GetEntryAssembly(), _serviceProvider);
        await _commandService.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), _serviceProvider);

        _logger.LogInformation("Connection to Discord Established ...");
    }
}