using CouchBotOSS.Shared.Models.Twitch;

namespace CouchBotOSS.Accessors.Contracts;

public interface ITwitchAccessor
{
    Task<TwitchStreamResponse> GetStreamsAsync(string twitchIdList, 
        CancellationToken cancellationToken);

    Task<TwitchUserResponse> GetUsersAsync(string twitchIdList,
        CancellationToken cancellationToken);

    Task<TwitchTeam> GetTwitchTeamByNameAsync(string name,
        CancellationToken cancellationToken);

    Task<TwitchStreamResponse> GetStreamsByGameNameAsync(string gameName,
        CancellationToken cancellationToken);

    Task<TwitchGameSearchResponse> SearchForGameByNameAsync(string gameName,
        CancellationToken cancellationToken);

    Task<TwitchClipsResponse> GetClipsAsync(string channelId,
        CancellationToken cancellationToken);
}