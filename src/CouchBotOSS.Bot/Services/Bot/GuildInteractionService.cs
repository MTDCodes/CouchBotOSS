using Discord.WebSocket;

namespace MTD.CouchBot.Services;

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