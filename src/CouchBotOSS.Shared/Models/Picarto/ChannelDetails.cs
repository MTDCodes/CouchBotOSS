using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Picarto;

public class ChannelDetails
{
    [JsonProperty("user_id")]
    public int UserId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("avatar")]
    public string Avatar { get; set; }

    [JsonProperty("online")]
    public bool Online { get; set; }

    [JsonProperty("viewers")]
    public int Viewers { get; set; }

    [JsonProperty("viewers_total")]
    public int ViewersTotal { get; set; }

    [JsonProperty("thumbnails")]
    public Thumbnails Thumbnails { get; set; }

    [JsonProperty("followers")]
    public int Followers { get; set; }

    [JsonProperty("subscribers")]
    public int Subscribers { get; set; }

    [JsonProperty("adult")]
    public bool Adult { get; set; }

    [JsonProperty("category")]
    public List<string> Category { get; set; }

    [JsonProperty("account_type")]
    public string AccountType { get; set; }

    [JsonProperty("commissions")]
    public bool Commissions { get; set; }

    [JsonProperty("recordings")]
    public bool Recordings { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description_panels")]
    public List<object> DescriptionPanels { get; set; }

    [JsonProperty("private")]
    public bool Private { get; set; }

    [JsonProperty("private_message")]
    public string PrivateMessage { get; set; }

    [JsonProperty("gaming")]
    public bool Gaming { get; set; }

    [JsonProperty("chat_settings")]
    public ChatSettings ChatSettings { get; set; }

    [JsonProperty("last_live")]
    public object LastLive { get; set; }

    [JsonProperty("tags")]
    public List<object> Tags { get; set; }

    [JsonProperty("multistream")]
    public object Multistream { get; set; }

    [JsonProperty("languages")]
    public List<Language> Languages { get; set; }

    [JsonProperty("following")]
    public bool Following { get; set; }

    [JsonProperty("creation_date")]
    public string CreationDate { get; set; }
}