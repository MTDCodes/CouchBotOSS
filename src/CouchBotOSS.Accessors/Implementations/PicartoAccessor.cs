using CouchBotOSS.Accessors.Contracts;
using CouchBotOSS.Shared.Helpers;
using CouchBotOSS.Shared.Models.Picarto;

namespace CouchBotOSS.Accessors.Implementations;

public class PicartoAccessor : IPicartoAccessor
{
    public async Task<PicartoChannel> GetChannelByNameAsync(string name,
        CancellationToken cancellationToken)
    {
        return await ApiHelper.GetAsync<PicartoChannel>($"https://ptvintern.picarto.tv/api/channel/detail/{name}",
            cancellationToken,
            new List<(string name, string value)>
        {
            ("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:88.0) Gecko/20100101 Firefox/88.0"),
            ("Accept", "*/*")
        });
    }
}