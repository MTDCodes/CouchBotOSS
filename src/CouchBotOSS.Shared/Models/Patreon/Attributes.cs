using Newtonsoft.Json;

namespace CouchBotOSS.Shared.Models.Patreon;

public class Attributes
{
    [JsonProperty("last_charge_date")]
    public DateTime? LastChargeDate { get; set; }

    [JsonProperty("last_charge_status")]
    public string LastChargeStatus { get; set; }

    [JsonProperty("patron_status")]
    public string PatronStatus { get; set; }

    [JsonProperty("pledge_cadence")]
    public int? PledgeCadence { get; set; }
}