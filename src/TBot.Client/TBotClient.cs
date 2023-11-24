using System.Text.Json;
using Microsoft.Extensions.Options;
using TBot.Client.Telegram;
using TBot.Core.CallLimiter;
using TBot.Core.HttpRequests;
using TBot.Core.Options;
using TBot.Core.Parameters;
using TBot.Core.TBot;
using TBot.Core.Telegram;
using TBot.Dto.Responses;
using TBot.Dto.Types;
using TBot.Dto.Updates;

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
    
    public Task<Response<Message>> SendMessageAsync(SendMessageParameters parameters)
    {
        var request = RequestDescriptor.Create(HttpMethod.Post, "/sendMessage", parameters.ToParameters().ToList());
        return SendAsync<Message, MessageDto>(request, dto => dto.ToDomain());
    }

    public Task<Response<List<Update>>> GetUpdateAsync(GetUpdateParameters parameters)
    {
        var request = RequestDescriptor.Create(HttpMethod.Post, "/getUpdates", parameters.ToParameters().ToList());
        return SendAsync<List<Update>, List<UpdateDto>>(request, 
            dtoList => dtoList.Select(x=>x.ToDomain()).ToList());
    }
    
    public async Task<Response<TResponseDomain>> SendAsync<TResponseDomain, TResponseDto>(
        RequestDescriptor request, Func<TResponseDto, TResponseDomain> convertor) where TResponseDomain : new()
    {
        var response = await SendAsync(request);
        var responseSteam = await response.Content.ReadAsStreamAsync();
        var responseDto = await JsonSerializer.DeserializeAsync<ResponseDto<TResponseDto>>(responseSteam);

        if (responseDto is null) {
            throw new Exception();
        }

        return Response<TResponseDomain>.Create(
            responseDto.StatusOk,
            convertor(responseDto.Result!),
            responseDto.Description,
            responseDto.ErrorCode,
            responseDto.ResponseParameters?.ToDomain());
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