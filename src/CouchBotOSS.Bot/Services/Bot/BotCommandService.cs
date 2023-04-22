using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;

namespace CouchBotOSS.Bot.Services.Bot;

public class BotCommandService
{
    private readonly CommandService _commands;
    private readonly DiscordSocketClient _discordSocketClient;
    private readonly InteractionService _interactionService;
    private readonly IServiceProvider _serviceProvider;

    public BotCommandService(
        CommandService commands,
        DiscordSocketClient discordSocketClient,
        InteractionService interactionService,
        IServiceProvider serviceProvider)
    {
        _commands = commands;
        _discordSocketClient = discordSocketClient;
        _interactionService = interactionService;
        _serviceProvider = serviceProvider;
    }

    public void Init()
    {
        _discordSocketClient.MessageReceived += HandleCommandAsync;
        _discordSocketClient.SlashCommandExecuted += async interaction =>
        {
            var ctx = new SocketInteractionContext<SocketSlashCommand>(_discordSocketClient, interaction);
            await _interactionService.ExecuteCommandAsync(ctx, _serviceProvider);
        };
    }

    private async Task HandleCommandAsync(SocketMessage arg)
    {
        var msg = arg as SocketUserMessage;
        if (msg == null || msg.Author.IsBot || msg.Author.Id == _discordSocketClient.CurrentUser.Id)
        {
            return;
        }

        int pos = 0;
        if (msg.HasMentionPrefix(_discordSocketClient.CurrentUser, ref pos))
        {
            var context = new SocketCommandContext(_discordSocketClient, msg);
            var _ = await _commands.ExecuteAsync(context, pos, _serviceProvider);
        }
    }
}