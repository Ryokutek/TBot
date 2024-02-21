using TBot.Core.HttpRequests;

namespace TBot.Client.Services.HttpRequests;

// ReSharper disable once InconsistentNaming
public class TBotRequestService(HttpClient httpClient) : IRequestService
{
    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
    {
        return httpClient.SendAsync(request);
    }
}