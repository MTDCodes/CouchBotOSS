using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.YouTube;

public class YouTubePlaylist
{
    [JsonProperty("kind")]
    public string Kind { get; set; }

    [JsonProperty("etag")]
    public string Etag { get; set; }

    [JsonProperty("nextPageToken")]
    public string NextPageToken { get; set; }

    [JsonProperty("items")]
    public List<Item> Items { get; set; }

    [JsonProperty("pageInfo")]
    public PageInfo NextPageInfo { get; set; }

    public class Default
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Medium
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class High
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Standard
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Maxres
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Thumbnails
    {
        [JsonProperty("default")]
        public Default Default { get; set; }

        [JsonProperty("medium")]
        public Medium Medium { get; set; }

        [JsonProperty("high")]
        public High High { get; set; }

        [JsonProperty("standard")]
        public Standard Standard { get; set; }

        [JsonProperty("maxres")]
        public Maxres Maxres { get; set; }
    }

    public class ResourceId
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("videoId")]
        public string VideoId { get; set; }
    }

    public class Snippet
    {
        [JsonProperty("publishedAt")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("channelId")]
        public string ChannelId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("thumbnails")]
        public Thumbnails Thumbnails { get; set; }

        [JsonProperty("channelTitle")]
        public string ChannelTitle { get; set; }

        [JsonProperty("playlistId")]
        public string PlaylistId { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("resourceId")]
        public ResourceId ResourceId { get; set; }

        [JsonProperty("videoOwnerChannelTitle")]
        public string VideoOwnerChannelTitle { get; set; }

        [JsonProperty("videoOwnerChannelId")]
        public string VideoOwnerChannelId { get; set; }
    }

    public class ContentDetails
    {
        [JsonProperty("videoId")]
        public string VideoId { get; set; }

        [JsonProperty("videoPublishedAt")]
        public DateTime VideoPublishedAt { get; set; }
    }

    public class Status
    {
        [JsonProperty("privacyStatus")]
        public string PrivacyStatus { get; set; }
    }

    public class Item
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("snippet")]
        public Snippet Snippet { get; set; }

        [JsonProperty("contentDetails")]
        public ContentDetails ContentDetails { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}