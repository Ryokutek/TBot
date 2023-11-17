using TBot.Core.HttpRequests;
using TBot.Core.HttpResponse;
using TBot.Core.Parameters;
using TBot.Core.Telegram;

namespace TBot.Core.TBot;

public interface ITBotClient
{
    Task<Result<Message>> SendMessageAsync(SendMessageParameters parameters);
    Task<Result<List<Update>>> GetUpdateAsync(GetUpdateParameters parameters);
    Task<HttpResponseMessage> SendAsync(RequestDescriptor request);
}