using Discord.WebSocket;

namespace CouchBotOSS.Bot.Services.Bot;

public class GuildInteractionService
{
    private readonly DiscordSocketClient _discordSocketClient;

    public GuildInteractionService(DiscordSocketClient discordSocketClient)
    {
        _discordSocketClient = discordSocketClient;
    }

    public void Init()
    {
        // Will add inits for all of our guild events.
    }
}