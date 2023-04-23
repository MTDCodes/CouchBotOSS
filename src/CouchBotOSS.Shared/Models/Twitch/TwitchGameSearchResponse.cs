using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Twitch;

public class TwitchGameSearchResponse
{
    [JsonProperty("data")]
    public List<Datum> Data { get; set; }

    public class Datum
    {
        [JsonProperty("box_art_url")]
        public string BoxArtUrl { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}