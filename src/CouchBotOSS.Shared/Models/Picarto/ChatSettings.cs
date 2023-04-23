using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Picarto;

public class ChatSettings
{
    [JsonProperty("guest_chat")]
    public bool GuestChat { get; set; }

    [JsonProperty("links")]
    public bool Links { get; set; }

    [JsonProperty("level")]
    public bool Level { get; set; }
}