using CouchBotOSS.Shared.Models.Patreon;

namespace CouchBotOSS.Accessors.Contracts;

public interface IPatreonAccessor
{
    Task<CampaignMemberResponse> ListAsync(CancellationToken cancellationToken);
}