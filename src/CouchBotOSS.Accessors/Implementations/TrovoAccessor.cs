using CouchBotOSS.Accessors.Contracts;
using CouchBotOSS.Accessors.Models;
using CouchBotOSS.Shared.Helpers;
using CouchBotOSS.Shared.Models.Bot;
using CouchBotOSS.Shared.Models.Trovo;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CouchBotOSS.Accessors.Implementations;

public class TrovoAccessor : ITrovoAccessor
{
    private readonly TokenConfiguration tokenConfiguration;

    public TrovoAccessor(IOptions<TokenConfiguration> tokenConfiguration)
    {
        this.tokenConfiguration = tokenConfiguration.Value;
    }

    public async Task<TrovoUser> GetUserByNameAsync(string name,
        CancellationToken cancellationToken)
    {
        var query = new TrovoUserQuery
        {
            User = new List<string>
            {
                name
            }
        };

        return await ApiHelper.PostAsync<TrovoUser>(
            "https://open-api.trovo.live/openplatform/getusers",
            cancellationToken,
            new List<(string name, string value)> { ("Client-Id", tokenConfiguration.TrovoClientId) },
            JsonConvert.SerializeObject(query));
    }

    public async Task<TrovoChannel> GetChannelByIdAsync(int id,
        CancellationToken cancellationToken)
    {
        var query = new TrovoQuery
        {
            ChannelId = id
        };

        return await ApiHelper.PostAsync<TrovoChannel>(
            "https://open-api.trovo.live/openplatform/channels/id",
            cancellationToken,
            new List<(string name, string value)> { ("Client-Id", tokenConfiguration.TrovoClientId) },
            JsonConvert.SerializeObject(query));
    }
}