using CouchBotOSS.Accessors.Contracts;
using CouchBotOSS.Shared.Helpers;
using CouchBotOSS.Shared.Models.Bot;
using CouchBotOSS.Shared.Models.YouTube;
using Microsoft.Extensions.Options;

namespace CouchBotOSS.Accessors.Implementations;

public class YouTubeAccessor : IYouTubeAccessor
{
    private readonly TokenConfiguration _tokenConfiguration;
    private readonly List<(string name, string value)> _youtubeHeaders;
    private const string BaseApiUrl = "https://www.googleapis.com/youtube/v3";

    public YouTubeAccessor(IOptions<TokenConfiguration> botSettings)
    {
        _tokenConfiguration = botSettings.Value;

        _youtubeHeaders = new List<(string name, string value)>{
            ("Content-Type", "application/json; charset=utf-8")
        };
    }

    public async Task<YouTubeChannelStatistics> GetChannelStatisticsByIdAsync(string id,
        CancellationToken cancellationToken)
    {
        return await ApiHelper.GetAsync<YouTubeChannelStatistics>($"{BaseApiUrl}/channels?part=statistics&key={_tokenConfiguration.YouTubeApiKey}&id={id}",
            cancellationToken, 
            _youtubeHeaders);
    }

    public async Task<YouTubeSearchListChannel> GetVideoByIdAsync(string id,
        CancellationToken cancellationToken)
    {
        return await ApiHelper.GetAsync<YouTubeSearchListChannel>($"{BaseApiUrl}/videos?part=snippet,statistics,liveStreamingDetails&key={_tokenConfiguration.YouTubeApiKey}&id={id}",
            cancellationToken,
            _youtubeHeaders);
    }

    public async Task<YouTubePlaylist> GetPlaylistItemsByPlaylistIdAsync(string playlistId,
        CancellationToken cancellationToken)
    {
        return await ApiHelper.GetAsync<YouTubePlaylist>($"{BaseApiUrl}/playlistItems?part=snippet,contentDetails,status&maxResults=5&key={_tokenConfiguration.YouTubeApiKey}&playlistId={playlistId}",
            cancellationToken,
            _youtubeHeaders);
    }

    public async Task<YouTubeChannelSearchList> GetYouTubeChannelByQueryAsync(string name,
        CancellationToken cancellationToken)
    {
        return await ApiHelper.GetAsync<YouTubeChannelSearchList>($"{BaseApiUrl}/search?part=snippet&q={name}&type=channel&key={_tokenConfiguration.YouTubeApiKey}",
            cancellationToken,
            _youtubeHeaders);
    }

    public async Task<YouTubeChannelSearchList> GetYouTubeChannelByUsernameAsync(string username,
        CancellationToken cancellationToken)
    {
        return await ApiHelper.GetAsync<YouTubeChannelSearchList>($"{BaseApiUrl}/channels?part=snippet,contentDetails&forUsername={username}&type=channel&key={_tokenConfiguration.YouTubeApiKey}",
            cancellationToken,
            _youtubeHeaders);
    }

    public async Task<YouTubeChannelByIdResponse> GetYouTubeChannelById(string channelId,
        CancellationToken cancellationToken)
    {
        return await ApiHelper.GetAsync<YouTubeChannelByIdResponse>($"{BaseApiUrl}/channels?part=snippet,contentDetails&id={channelId}&key={_tokenConfiguration.YouTubeApiKey}",
            cancellationToken,
            _youtubeHeaders);
    }

    public async Task<LiveChatStatusResponse> GetLiveChannelsAsync(string channelIds,
        CancellationToken cancellationToken)
    {
        return await ApiHelper.GetAsync<LiveChatStatusResponse>($"{BaseApiUrl}/liveChat/status?" +
                                                                    $"channelId={channelIds}&part=snippet&key={_tokenConfiguration.YouTubeApiKey}&" +
                                                                    "fields=items(snippet(channelId,currentVideoId))",
            cancellationToken,
            _youtubeHeaders);
    }

    public async Task<YouTubeVideoListResponse> GetVideoDetailsAsync(string videoId,
        CancellationToken cancellationToken)
    {
        return await ApiHelper.GetAsync<YouTubeVideoListResponse>($"{BaseApiUrl}/videos?part=snippet,contentDetails,status,liveStreamingDetails&key={_tokenConfiguration.YouTubeApiKey}&id={videoId}",
            cancellationToken,
            _youtubeHeaders);
    }

    public async Task<List<YouTubeChannelByIdResponse>> GetYouTubeChannelsByIds(string channelIds,
        CancellationToken cancellationToken)
    {
        return await ApiHelper.GetAsync<List<YouTubeChannelByIdResponse>>($"{BaseApiUrl}/channels?part=snippet,contentDetails&id={channelIds}&key={_tokenConfiguration.YouTubeApiKey}",
            cancellationToken,
            _youtubeHeaders);
    }
}