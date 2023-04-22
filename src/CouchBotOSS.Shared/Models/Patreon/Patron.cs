namespace CouchBotOSS.Shared.Models.Patreon;

public class Patron
{
    public string PatreonId { get; set; }
    public string DiscordId { get; set; }
    public int TierId { get; set; }
    public DateTime EndDate { get; set; }
}