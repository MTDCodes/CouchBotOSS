using CouchBotOSS.Bot.Services.Bot;
using CouchBotOSS.Bot.Services.Hosted;
using CouchBotOSS.Shared.Models.Bot;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using MTD.CouchBot.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddOptions();
        services.Configure<TokenConfiguration>(context.Configuration.GetSection(nameof(TokenConfiguration)));

        var socketConfig = new DiscordSocketConfig
        {
            GatewayIntents =
                GatewayIntents.GuildVoiceStates |
                GatewayIntents.GuildScheduledEvents |
                GatewayIntents.DirectMessages |
                GatewayIntents.GuildIntegrations |
                GatewayIntents.GuildMembers |
                GatewayIntents.GuildMessageReactions |
                GatewayIntents.GuildPresences |
                GatewayIntents.Guilds | 
                GatewayIntents.MessageContent |
                GatewayIntents.GuildMessages,
            LogLevel = LogSeverity.Warning,
            AlwaysDownloadUsers = true
        };

        services.AddSingleton(new DiscordSocketClient(socketConfig));
        services.AddSingleton<Discord.Commands.CommandService>();
        services.AddSingleton<BotCommandService>();
        services.AddSingleton<InteractionService>();
        services.AddSingleton<GuildInteractionService>();
        services.AddSingleton<MessageInteractionService>();
        services.AddSingleton<StartupService>();

        services.AddHostedService<BotService>();
    })
    .Build();

host.Run();
