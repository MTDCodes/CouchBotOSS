using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.YouTube;

public class LiveChatStatusResponse
{
    [JsonProperty("items")]
    public List<Item> Items { get; set; }

    public class Snippet
    {
        [JsonProperty("channelId")]
        public string ChannelId { get; set; }

        [JsonProperty("currentVideoId")]
        public string CurrentVideoId { get; set; }
    }

    public class Item
    {
        [JsonProperty("snippet")]
        public Snippet Snippet { get; set; }
    }
}