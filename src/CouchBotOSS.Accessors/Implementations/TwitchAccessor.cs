using System.Xml;
using CouchBotOSS.Accessors.Contracts;
using CouchBotOSS.Shared.Helpers;
using CouchBotOSS.Shared.Models.Bot;
using CouchBotOSS.Shared.Models.Twitch;
using Microsoft.Extensions.Options;

namespace CouchBotOSS.Accessors.Implementations;

public class TwitchAccessor : ITwitchAccessor
{
    private const string BaseApiUrl = "https://api.twitch.tv/helix/";

    private readonly TokenConfiguration _tokenConfiguration;

    private List<(string name, string value)> _twitchHeaders;

    private DateTime TokenRetrieved { get; set; }

    private TwitchClientCredentials TwitchClientCredentials { get; set; }

    public TwitchAccessor(IOptions<TokenConfiguration> tokenConfiguration)
    {
        _tokenConfiguration = tokenConfiguration.Value;
    }

    public async Task<TwitchStreamResponse> GetStreamsAsync(string twitchIdList,
        CancellationToken cancellationToken) => await ApiHelper.GetAsync<TwitchStreamResponse>($"{BaseApiUrl}streams?{twitchIdList}&first=100",
            cancellationToken,
            await GetTwitchHeaders(cancellationToken));

    public async Task<TwitchUserResponse> GetUsersAsync(string twitchIdList,
        CancellationToken cancellationToken) => await ApiHelper.GetAsync<TwitchUserResponse>($"{BaseApiUrl}users?{twitchIdList}",
            cancellationToken,
            await GetTwitchHeaders(cancellationToken));

    public async Task<TwitchTeam> GetTwitchTeamByNameAsync(string name,
        CancellationToken cancellationToken) => await ApiHelper.GetAsync<TwitchTeam>($"{BaseApiUrl}teams?name={name}",
            cancellationToken,
            await GetTwitchHeaders(cancellationToken));

    public async Task<TwitchStreamResponse> GetStreamsByGameNameAsync(string gameId,
        CancellationToken cancellationToken) => await ApiHelper.GetAsync<TwitchStreamResponse>($"{BaseApiUrl}streams?game_id={gameId}",
            cancellationToken,
            await GetTwitchHeaders(cancellationToken));

    public async Task<TwitchGameSearchResponse> SearchForGameByNameAsync(string gameName,
        CancellationToken cancellationToken) => await ApiHelper.GetAsync<TwitchGameSearchResponse>($"{BaseApiUrl}search/categories?query={gameName}",
            cancellationToken,
            await GetTwitchHeaders(cancellationToken));

    public async Task<TwitchClipsResponse> GetClipsAsync(string channelId,
        CancellationToken cancellationToken)
    {
        var start = XmlConvert.ToString(DateTime.UtcNow.AddMinutes(-10), XmlDateTimeSerializationMode.Utc);
        var end = XmlConvert.ToString(DateTime.UtcNow, XmlDateTimeSerializationMode.Utc);

        return await ApiHelper.GetAsync<TwitchClipsResponse>($"{BaseApiUrl}clips?" +
                                                                 $"broadcaster_id={channelId}&" +
                                                                 $"started_at={start}&" +
                                                                 $"ended_at={end}",
            cancellationToken,
            _twitchHeaders);
    }

    private async Task<List<(string name, string value)>> GetTwitchHeaders(CancellationToken cancellationToken)
    {
        if ((DateTime.UtcNow - TokenRetrieved).TotalMinutes > 90)
        {
            TwitchClientCredentials = await ApiHelper.GetAsync<TwitchClientCredentials>(
                "https://id.twitch.tv/oauth2/token?" +
                $"client_id={_tokenConfiguration.TwitchClientId}&" +
                $"client_secret={_tokenConfiguration.TwitchClientSecret}&" +
                "grant_type=client_credentials",
                cancellationToken, 
                _twitchHeaders);

            if (TwitchClientCredentials == null)
            {
                // There was an error. Do something Matt! TODO LOGGING!!!!
            }

            TokenRetrieved = DateTime.UtcNow;
            _twitchHeaders?.Clear();
        }

        _twitchHeaders = new List<(string name, string value)>{
                ("Client-Id", _tokenConfiguration.TwitchClientId),
                ("Authorization", $"{TwitchClientCredentials.TokenType.FirstLetterToUpper()} {TwitchClientCredentials.AccessToken}")
            };

        return _twitchHeaders;
    }
}