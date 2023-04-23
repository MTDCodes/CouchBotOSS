using CouchBotOSS.Shared.Models.YouTube;

namespace CouchBotOSS.Accessors.Contracts;

public interface IYouTubeAccessor
{
    Task<YouTubeSearchListChannel> GetVideoByIdAsync(string id,
        CancellationToken cancellationToken);

    Task<YouTubeChannelStatistics> GetChannelStatisticsByIdAsync(string id,
        CancellationToken cancellationToken);

    Task<YouTubePlaylist> GetPlaylistItemsByPlaylistIdAsync(string playlistId,
        CancellationToken cancellationToken);

    Task<YouTubeChannelSearchList> GetYouTubeChannelByQueryAsync(string name,
        CancellationToken cancellationToken);

    Task<YouTubeChannelByIdResponse> GetYouTubeChannelById(string channelId,
        CancellationToken cancellationToken);

    Task<LiveChatStatusResponse> GetLiveChannelsAsync(string channelIds,
        CancellationToken cancellationToken);

    Task<YouTubeVideoListResponse> GetVideoDetailsAsync(string videoId,
        CancellationToken cancellationToken);

    Task<List<YouTubeChannelByIdResponse>> GetYouTubeChannelsByIds(string channelIds,
        CancellationToken cancellationToken);

    Task<YouTubeChannelSearchList> GetYouTubeChannelByUsernameAsync(string username,
        CancellationToken cancellationToken);
}