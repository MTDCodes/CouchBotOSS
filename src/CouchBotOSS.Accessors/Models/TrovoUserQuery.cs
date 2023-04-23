using Newtonsoft.Json;

namespace CouchBotOSS.Accessors.Models
{
    public class TrovoUserQuery
    {
        [JsonProperty("user")]
        public List<string> User { get; set; }
    }
}
