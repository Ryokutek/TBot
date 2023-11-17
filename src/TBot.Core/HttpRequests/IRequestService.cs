namespace TBot.Core.HttpRequests;

public interface IRequestService
{
    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
}