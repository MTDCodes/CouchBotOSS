using CouchBotOSS.Shared.Models.Patreon;

namespace MTD.CouchBot.Accessors.Contracts;

public interface IPatreonAccessor
{
    Task<CampaignMemberResponse> ListAsync(CancellationToken cancellationToken);
}