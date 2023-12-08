using TBot.Core.HttpRequests;
using TBot.Core.Parameters;
using TBot.Core.Telegram;

namespace TBot.Core.TBot;

public interface ITBotClient
{
    Task<Response<Message>> SendVideoAsync(SendVideoOptions options);
    Task<Response<Message>> SendMessageAsync(SendMessageOptions options);
    Task<Response<List<Update>>> GetUpdateAsync(GetUpdateOptions options);
    Task<Response<TResponseDomain>> SendAsync<TResponseDomain, TResponseDto>(
        RequestDescriptor request, Func<TResponseDto, TResponseDomain> convertor) where TResponseDomain : new();
    Task<HttpResponseMessage> SendAsync(RequestDescriptor request);
}