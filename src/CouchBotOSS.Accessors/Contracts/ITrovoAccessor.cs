using CouchBotOSS.Shared.Models.Trovo;

namespace CouchBotOSS.Accessors.Contracts;

public interface ITrovoAccessor
{
    Task<TrovoUser> GetUserByNameAsync(string name,
        CancellationToken cancellationToken);

    Task<TrovoChannel> GetChannelByIdAsync(int id,
        CancellationToken cancellationToken);
}