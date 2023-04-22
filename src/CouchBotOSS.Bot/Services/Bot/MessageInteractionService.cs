using Discord.WebSocket;

namespace MTD.CouchBot.Services;

public class MessageInteractionService
{
    private readonly DiscordSocketClient _discordSocketClient;

    public MessageInteractionService(DiscordSocketClient discordSocketClient)
    {
        _discordSocketClient = discordSocketClient;
    }

    public void Init()
    {
        // Will add inits for all of our message events.
    }
}