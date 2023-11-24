using TBot.Core.HttpRequests;
using TBot.Core.Parameters;
using TBot.Core.Telegram;

namespace TBot.Core.TBot;

public interface ITBotClient
{
    Task<Response<Message>> SendMessageAsync(SendMessageParameters parameters);
    Task<Response<List<Update>>> GetUpdateAsync(GetUpdateParameters parameters);
    Task<Response<TResponseDomain>> SendAsync<TResponseDomain, TResponseDto>(
        RequestDescriptor request, Func<TResponseDto, TResponseDomain> convertor) where TResponseDomain : new();
    Task<HttpResponseMessage> SendAsync(RequestDescriptor request);
}