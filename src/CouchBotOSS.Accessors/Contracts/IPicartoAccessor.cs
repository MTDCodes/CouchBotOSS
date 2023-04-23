using CouchBotOSS.Shared.Models.Picarto;

namespace CouchBotOSS.Accessors.Contracts;

public interface IPicartoAccessor
{
    Task<PicartoChannel> GetChannelByNameAsync(string name,
        CancellationToken cancellationToken);
}