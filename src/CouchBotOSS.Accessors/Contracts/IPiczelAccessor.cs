using CouchBotOSS.Shared.Models.Piczel;

namespace CouchBotOSS.Accessors.Contracts;

public interface IPiczelAccessor
{
    Task<PiczelChannelResponse> GetChannelByNameAsync(string name,
        CancellationToken cancellationToken);
}