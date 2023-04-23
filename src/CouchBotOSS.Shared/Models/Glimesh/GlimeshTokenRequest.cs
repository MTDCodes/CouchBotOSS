using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Glimesh;

public class GlimeshTokenRequest
{
    [JsonProperty("client_id")]
    public string ClientId { get; set; }

    [JsonProperty("client_secret")]
    public string ClientSecret { get; set; }

    [JsonProperty("grant_type")]
    public string GrantType { get; set; }

    public string Scope { get; set; }
}