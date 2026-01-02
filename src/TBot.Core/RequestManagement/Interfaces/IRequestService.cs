namespace TBot.Core.RequestManagement.Interfaces;

public interface IRequestService
{
    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
}