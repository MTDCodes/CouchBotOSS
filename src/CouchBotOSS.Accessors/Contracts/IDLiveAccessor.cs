using CouchBotOSS.Shared.Models.DLive;

namespace CouchBotOSS.Accessors.Contracts;

public interface IDLiveAccessor
{
    Task<DLiveUser> GetUserByDisplayNameAsync(string displayName,
        CancellationToken cancellationToken);

    Task<DLiveUser> GetUserByUsernameAsync(string username,
        CancellationToken cancellationToken);
}