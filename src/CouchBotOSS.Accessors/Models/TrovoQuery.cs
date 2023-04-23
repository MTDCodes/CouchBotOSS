using Newtonsoft.Json;

namespace CouchBotOSS.Accessors.Models
{
    public class TrovoQuery
    {
        [JsonProperty("channel_id")]
        public int ChannelId { get; set; }
    }
}
