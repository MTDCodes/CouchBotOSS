using CouchBotOSS.Shared.Dtos;

namespace CouchBotOSS.Accessors.Contracts
{
    public interface IDiscordUserAccessor
    {
        Task<List<DiscordUserDto>> ListAsync();
        Task<DiscordUserDto> RetrieveAsync(string discordUserId);
        Task<DiscordUserDto> RetrieveAsync(long id);
    }
}
