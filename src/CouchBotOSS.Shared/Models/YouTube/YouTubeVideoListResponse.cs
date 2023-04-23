using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.YouTube;

public class YouTubeVideoListResponse
{
    [JsonProperty("items")]
    public List<Item> Items { get; set; }

    public class Snippet
    {
        [JsonProperty("liveBroadcastContent")]
        public string LiveBroadcastContent { get; set; }
    }

    public class Item
    {
        [JsonProperty("snippet")]
        public Snippet Snippet { get; set; }
    }
}