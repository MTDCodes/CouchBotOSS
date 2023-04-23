using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Picarto;

public class PicartoChannel
{
    [JsonProperty("channel")]
    public Channel Channel { get; set; }
}