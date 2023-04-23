using CouchBotOSS.Accessors.Contracts;
using CouchBotOSS.Shared.Helpers;
using CouchBotOSS.Shared.Models.Piczel;

namespace CouchBotOSS.Accessors.Implementations;

public class PiczelAccessor : IPiczelAccessor
{
    public async Task<PiczelChannelResponse> GetChannelByNameAsync(string channelName,
        CancellationToken cancellationToken)
    {
        return await ApiHelper.GetAsync<PiczelChannelResponse>($"https://piczel.tv/api/streams/{channelName}",
            cancellationToken);
    }
}