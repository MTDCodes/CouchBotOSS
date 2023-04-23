using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Picarto;

public class Channel
{
    [JsonProperty("avatar")]
    public string Avatar { get; set; }

    [JsonProperty("color")]
    public string Color { get; set; }

    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("online")]
    public bool Online { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("total_views")]
    public int TotalViews { get; set; }

    [JsonProperty("viewers")]
    public int Viewers { get; set; }

    [JsonProperty("followers_count")]
    public int FollowersCount { get; set; }

    [JsonProperty("subscribers_count")]
    public int SubscribersCount { get; set; }

    [JsonProperty("avatar_url")]
    public string AvatarUrl { get; set; }

    [JsonProperty("image_thumbnail")]
    public string ImageThumbnail { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; }
}