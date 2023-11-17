using Microsoft.Extensions.Options;
using TBot.Client.Telegram;
using TBot.Client.Utilities;
using TBot.Core.CallLimiter;
using TBot.Core.HttpRequests;
using TBot.Core.HttpResponse;
using TBot.Core.Options;
using TBot.Core.Parameters;
using TBot.Core.TBot;
using TBot.Core.Telegram;
using TBot.Telegram.Dto.Responses;
namespace TBot.Client;

// ReSharper disable once InconsistentNaming
public class TBotClient : ITBotClient
{
    private readonly IRequestService _requestService;
    private readonly ICallLimiterService? _callLimitService;

    private readonly TBotOptions _botOptions;
    private readonly CallLimiterOptions? _limitConfig;

    public TBotClient(
        IOptions<TBotOptions> botOptions,
        IRequestService requestService, 
        IOptions<CallLimiterOptions>? limitConfig = null,
        ICallLimiterService? callLimitService = null)
    {
        _botOptions = botOptions.Value;
        _limitConfig = limitConfig?.Value;
        _requestService = requestService;
        _callLimitService = callLimitService;
    }
    
    public Task<Result<Message>> SendMessageAsync(SendMessageParameters parameters)
    {
        var request = RequestDescriptor.Create(HttpMethod.Post, "/sendMessage", parameters.ToParameters().ToList());
        return SendAsync<Message>(request);
    }

    public Task<Result<List<Update>>> GetUpdateAsync(GetUpdateParameters parameters)
    {
        var request = RequestDescriptor.Create(HttpMethod.Post, "/getUpdates", parameters.ToParameters().ToList());
        return SendAsync<List<Update>>(request);
    }
    
    private async Task<Result<TResponse>> SendAsync<TResponse>(RequestDescriptor request) where TResponse : new()
    {
        var response = await SendAsync(request);
        var dto = (await response.DeserializeAsync<ResponseDto>())!;
        var domain = Response<TResponse>.Create(
            dto.StatusOk,
            dto.Result is not null ? dto.Result.ToObject<TResponse>() : new TResponse(),
            dto.Description,
            dto.ErrorCode,
            dto.ResponseParameters?.ToDomain());

        return Result<TResponse>.Create(domain, response);
    }
    
    public async Task<HttpResponseMessage> SendAsync(RequestDescriptor request)
    {
        var telegramRequest = TelegramRequest.Create(_botOptions.Token, request);
        
        if (_callLimitService is not null && !string.IsNullOrEmpty(telegramRequest.ChatId)) {
            await _callLimitService.WaitAsync(telegramRequest.ChatId, _limitConfig!); 
        }

        return await _requestService.SendAsync(telegramRequest.Build());
    }
}