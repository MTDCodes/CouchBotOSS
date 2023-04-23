using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Twitch;

public class TwitchStreamResponse
{
    [JsonProperty("data")]
    public List<Datum> Data { get; set; }

    //[JsonProperty("pagination")]
    //public Pagination Pagination { get; set; }

    public class Datum
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("user_login")]
        public string UserLogin { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("game_id")]
        public string GameId { get; set; }

        [JsonProperty("game_name")]
        public string GameName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("viewer_count")]
        public int ViewerCount { get; set; }

        [JsonProperty("started_at")]
        public DateTime StartedAt { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("tag_ids")]
        public List<string> TagIds { get; set; }
    }

    //public class Pagination
    //{
    //    [JsonProperty("cursor")]
    //    public string Cursor { get; set; }
    //}
}