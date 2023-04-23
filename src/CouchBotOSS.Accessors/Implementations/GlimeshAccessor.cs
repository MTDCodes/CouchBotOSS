using CouchBotOSS.Accessors.Contracts;
using CouchBotOSS.Accessors.Models;
using CouchBotOSS.Shared.Helpers;
using CouchBotOSS.Shared.Models.Bot;
using CouchBotOSS.Shared.Models.Glimesh;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CouchBotOSS.Accessors.Implementations;

public class GlimeshAccessor : IGlimeshAccessor
{
    private readonly TokenConfiguration _tokenConfiguration;

    private GlimeshTokenResponse _tokenResponse;

    public DateTime LastRetrievedToken { get; set; }

    public GlimeshAccessor(IOptions<TokenConfiguration> tokenConfiguration)
    {
        _tokenConfiguration = tokenConfiguration.Value;
    }

    public async Task<GlimeshChannel> GetChannelByNameAsync(string name,
        CancellationToken cancellationToken)
    {
        try
        {
            var query = new GlimeshQuery
            {
                Query =
                    "{\n  channel(username:\"" + name + "\") \n  {\n	  title,\n	  status,\n	  stream {\n		thumbnail\n	  },\n	  streamer {\n		  avatar,\n		  username\n	  },\n	  category {\n		name\n	  }\n  }\n}",
                OperationName = null,
                Variables = null
            };

            return await ApiHelper.PostAsync<GlimeshChannel>("https://glimesh.tv/api", 
                cancellationToken,
                await GetHeaders(cancellationToken), 
                JsonConvert.SerializeObject(query));
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<GlimeshMyselfQueryResponse> RetrieveAsync(string accessToken,
        CancellationToken cancellationToken)
    {
        var query = new GlimeshQuery
        {
            Query =
                "query {\r\n myself {\r\n username,\r\n id\r\n}\r\n}",
            OperationName = null,
            Variables = null
        };

        return await ApiHelper.PostAsync<GlimeshMyselfQueryResponse>("https://glimesh.tv/api", 
            cancellationToken,
            await GetHeaders(cancellationToken),
            JsonConvert.SerializeObject(query));
    }

    private async Task<GlimeshTokenResponse> GetAccessToken(CancellationToken cancellationToken)
    {
        var request = new GlimeshTokenRequest
        {
            ClientId = _tokenConfiguration.GlimeshClientId,
            ClientSecret = _tokenConfiguration.GlimeshClientSecret,
            GrantType = "client_credentials",
            Scope = "streamkey"
        };

        return await ApiHelper.PostAsync<GlimeshTokenResponse>("https://glimesh.tv/api/oauth/token",
            cancellationToken,
            payloadString: JsonConvert.SerializeObject(request));
    }

    private async Task<List<(string name, string value)>> GetHeaders(CancellationToken cancellationToken)
    {
        if ((DateTime.UtcNow - LastRetrievedToken).TotalMinutes > 30)
        {
            _tokenResponse = await GetAccessToken(cancellationToken);
            LastRetrievedToken = DateTime.UtcNow;
        }

        return new List<(string name, string value)> { ("Authorization", $"Bearer {_tokenResponse.AccessToken}") };
    }
}