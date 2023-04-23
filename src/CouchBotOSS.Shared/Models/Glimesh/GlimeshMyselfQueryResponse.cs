using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Glimesh;

public class GlimeshMyselfQueryResponse
{
    [JsonProperty("data")]
    public Data ResponseData { get; set; }

    public class Myself
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public class Data
    {
        [JsonProperty("myself")]
        public Myself Myself { get; set; }
    }
}