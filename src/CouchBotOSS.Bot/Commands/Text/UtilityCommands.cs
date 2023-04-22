using Discord.Commands;

namespace CouchBotOSS.Bot.Commands.Text
{
    public class UtilityCommands : ModuleBase
    {
        [Command("ping", RunMode = RunMode.Async)]
        public async Task PingAsync()
        {
            await ReplyAsync("Pong!");
        }
    }
}
