namespace CouchBotOSS.Shared.Models.Patreon;

public class CampaignMemberResponse
{
    public List<CampaignMemberData> Data { get; set; }
    public List<CampaignMemberIncluded> Included { get; set; }
    public Links Links { get; set; }
}