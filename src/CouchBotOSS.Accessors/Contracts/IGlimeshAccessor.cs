using CouchBotOSS.Shared.Models.Glimesh;

namespace CouchBotOSS.Accessors.Contracts;

public interface IGlimeshAccessor
{
    Task<GlimeshChannel> GetChannelByNameAsync(string name, 
        CancellationToken cancellationToken);

    Task<GlimeshMyselfQueryResponse> RetrieveAsync(string accessToken,
        CancellationToken cancellationToken);
}