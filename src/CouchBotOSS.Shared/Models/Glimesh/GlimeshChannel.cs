using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Glimesh;

public class GlimeshChannel
{
    [JsonProperty("data")]
    public Data ResponseData { get; set; }

    public class Category
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Stream
    {
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }

    public class Streamer
    {
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public class Channel
    {
        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("stream")]
        public Stream Stream { get; set; }

        [JsonProperty("streamer")]
        public Streamer Streamer { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class Data
    {
        [JsonProperty("channel")]
        public Channel Channel { get; set; }
    }
}