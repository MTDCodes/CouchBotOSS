using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Glimesh;

public class GlimeshTokenResponse
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("refresh_token")]
    public object RefreshToken { get; set; }

    public string Scope { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }
}