using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Piczel;

public class PiczelChannelResponse
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("data")]
    public List<Datum> Data { get; set; }

    [JsonProperty("meta")]
    public Meta Meta_ { get; set; }

    public class OfflineImage
    {
        [JsonProperty("url")]
        public object Url { get; set; }
    }

    public class Banner2
    {
        [JsonProperty("url")]
        public object Url { get; set; }
    }

    public class Banner
    {
        [JsonProperty("banner")]
        public Banner2 Banner_ { get; set; }
    }

    public class Preview
    {
        [JsonProperty("url")]
        public object Url { get; set; }
    }

    public class Basic
    {
        [JsonProperty("listed")]
        public bool Listed { get; set; }

        [JsonProperty("allowAnon")]
        public bool AllowAnon { get; set; }

        [JsonProperty("notifications")]
        public bool Notifications { get; set; }
    }

    public class Recording
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("download")]
        public bool Download { get; set; }

        [JsonProperty("timelapse_speed")]
        public int TimelapseSpeed { get; set; }

        [JsonProperty("watermark_timelapse")]
        public bool WatermarkTimelapse { get; set; }

        [JsonProperty("gen_timelapse")]
        public bool GenTimelapse { get; set; }
    }

    public class Private
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("moderated")]
        public bool Moderated { get; set; }
    }

    public class Emails
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

    public class Settings
    {
        [JsonProperty("basic")]
        public Basic Basic { get; set; }

        [JsonProperty("recording")]
        public Recording Recording { get; set; }

        [JsonProperty("private")]
        public Private Private { get; set; }

        [JsonProperty("emails")]
        public Emails Emails { get; set; }
    }

    public class Avatar
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Gallery
    {
        [JsonProperty("profile_description")]
        public string ProfileDescription { get; set; }
    }

    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("premium?")]
        public bool Premium { get; set; }

        [JsonProperty("avatar")]
        public Avatar Avatar { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("gallery")]
        public Gallery Gallery { get; set; }

        [JsonProperty("follower_count")]
        public int FollowerCount { get; set; }
    }

    public class Datum
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("rendered_description")]
        public string RenderedDescription { get; set; }

        [JsonProperty("follower_count")]
        public int FollowerCount { get; set; }

        [JsonProperty("live")]
        public bool Live { get; set; }

        [JsonProperty("live_since")]
        public DateTime? LiveSince { get; set; }

        [JsonProperty("isPrivate?")]
        public bool IsPrivate { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("offline_image")]
        public OfflineImage OfflineImage { get; set; }

        [JsonProperty("banner")]
        public Banner Banner { get; set; }

        [JsonProperty("banner_link")]
        public object BannerLink { get; set; }

        [JsonProperty("preview")]
        public Preview Preview { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("in_multi")]
        public bool InMulti { get; set; }

        [JsonProperty("parent_streamer")]
        public object ParentStreamer { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        [JsonProperty("viewers")]
        public string Viewers { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("tags")]
        public List<object> Tags { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("recordings")]
        public List<object> Recordings { get; set; }
    }

    public class Meta
    {
        [JsonProperty("limit_reached")]
        public bool LimitReached { get; set; }
    }
}