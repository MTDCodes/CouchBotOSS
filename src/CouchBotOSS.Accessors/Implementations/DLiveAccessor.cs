using CouchBotOSS.Accessors.Contracts;
using CouchBotOSS.Accessors.Models;
using CouchBotOSS.Shared.Helpers;
using CouchBotOSS.Shared.Models.DLive;
using Newtonsoft.Json;

namespace CouchBotOSS.Accessors.Implementations;

public class DLiveAccessor : IDLiveAccessor
{
    private const string DLiveUrl = "https://graphigo.prd.dlive.tv/";
    private const string GetUserByDisplayNameQuery =
        "query {" +
        "userByDisplayName(displayname:\"%DISPLAYNAME%\") {" +
        "   id" +
        "   username" +
        "   displayname" +
        "}" +
        "}";

    private const string GetUserByUsernameQuery =
        "query {" +
        "user(username:\"%USERNAME%\") { " +
        "displayname " +
        "avatar " +
        "followers {" +
        "totalCount " +
        "} " +
        "livestream { " +
        "thumbnailUrl " +
        "title " +
        "watchingCount " +
        "category " +
        "{ " +
        "title " +
        "} " +
        "} " +
        "} " +
        "}";

    public async Task<DLiveUser> GetUserByDisplayNameAsync(string displayName,
        CancellationToken cancellationToken)
    {
        var query = GetUserByDisplayNameQuery.Replace("%DISPLAYNAME%", displayName);

        var dliveQuery = new DLiveQuery
        {
            Query = query,
            OperationName = null,
            Variables = null
        };

        return await ApiHelper.PostAsync<DLiveUser>(DLiveUrl, 
            cancellationToken, 
            payloadString: JsonConvert.SerializeObject(dliveQuery));
    }

    public async Task<DLiveUser> GetUserByUsernameAsync(string username,
        CancellationToken cancellationToken)
    {
        var query = GetUserByUsernameQuery.Replace("%USERNAME%", username);

        var dliveQuery = new DLiveQuery
        {
            Query = query,
            OperationName = null,
            Variables = null
        };

        return await ApiHelper.PostAsync<DLiveUser>(DLiveUrl, 
            cancellationToken, 
            payloadString: JsonConvert.SerializeObject(dliveQuery));
    }
}