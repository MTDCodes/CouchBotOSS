using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Picarto;

public class Thumbnails
{
    [JsonProperty("web")]
    public string Web { get; set; }

    [JsonProperty("web_large")]
    public string WebLarge { get; set; }

    [JsonProperty("mobile")]
    public string Mobile { get; set; }

    [JsonProperty("tablet")]
    public string Tablet { get; set; }
}