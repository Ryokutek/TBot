using TBot.Core.HttpRequests;

namespace TBot.Client.Services.HttpRequests;

// ReSharper disable once InconsistentNaming
public class TBotRequestService : IRequestService
{
    private readonly HttpClient _httpClient;

    public TBotRequestService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
    {
        return _httpClient.SendAsync(request);
    }
}