using Newtonsoft.Json;

namespace CouchBotOSS.Accessors.Models
{
    public class BaseQuery
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("variables")]
        public object Variables { get; set; }

        [JsonProperty("operationName")]
        public object OperationName { get; set; }
    }
}
