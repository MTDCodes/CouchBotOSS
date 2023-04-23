using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Picarto;

public class Language
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}