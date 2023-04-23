using CouchBotOSS.Accessors.Contracts;
using CouchBotOSS.Shared.Helpers;
using CouchBotOSS.Shared.Models.Bot;
using CouchBotOSS.Shared.Models.Patreon;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace CouchBotOSS.Accessors.Implementations;

public class PatreonAccessor : IPatreonAccessor
{
    private readonly PatreonConfiguration _patreonConfiguration;
    private readonly IMemoryCache _memoryCache;
    private readonly List<(string name, string value)> _headers;

    public PatreonAccessor(
        IOptions<PatreonConfiguration> patreonConfiguration,
        IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
        _patreonConfiguration = patreonConfiguration.Value;

        _headers = new List<(string name, string value)> { ("Authorization", $"Bearer {_patreonConfiguration.AccessToken}") };
    }

    public async Task<CampaignMemberResponse> ListAsync(CancellationToken cancellationToken)
    {
        var cacheKey = "PatreonList";

        if (_memoryCache.TryGetValue(cacheKey, out CampaignMemberResponse campaignMemberResponse))
        {
        }
        else
        {
            campaignMemberResponse ??= new CampaignMemberResponse
            {
                Data = new List<CampaignMemberData>(),
                Included = new List<CampaignMemberIncluded>(),
                Links = new Links()
            };

            var pledgeEndpoint =
                $"https://www.patreon.com/api/oauth2/v2/campaigns/{_patreonConfiguration.CampaignId}/members?include=currently_entitled_tiers,user&fields%5Bmember%5D=patron_status,last_charge_status,last_charge_date,pledge_cadence&fields%5Buser%5D=social_connections";

            try
            {
                var response = await ApiHelper.GetAsync<CampaignMemberResponse>(pledgeEndpoint, cancellationToken, _headers);

                campaignMemberResponse.Data.AddRange(response.Data);
                campaignMemberResponse.Included.AddRange(response.Included);

                while (!string.IsNullOrEmpty(response.Links?.Next))
                {
                    response = await ApiHelper.GetAsync<CampaignMemberResponse>(response.Links.Next, cancellationToken, _headers);

                    campaignMemberResponse.Data.AddRange(response.Data);
                    campaignMemberResponse.Included.AddRange(response.Included);
                }

                // Set memory cache to 5 minutes.
                _memoryCache.Set(cacheKey, campaignMemberResponse, new TimeSpan(0, 0, 5, 0, 0));
            }
            catch (Exception)
            {
                Console.WriteLine("Matt needs to do better. Tell him this.");
            }
        }

        return campaignMemberResponse;
    }
}