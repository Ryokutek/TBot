using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TBot.Client.Telegram;
using TBot.Core.CallLimiter;
using TBot.Core.ConfigureOptions;
using TBot.Core.HttpRequests;
using TBot.Core.RequestOptions;
using TBot.Core.RequestOptions.Structure;
using TBot.Core.TBot;
using TBot.Core.Telegram;
using TBot.Dto.Responses;
using TBot.Dto.Types;
using TBot.Dto.Updates;

namespace TBot.Client;

// ReSharper disable once InconsistentNaming
public class TBotClient : ITBotClient
{
    private readonly ILogger<ITBotClient>? _logger;
    private readonly IRequestService _requestService;
    private readonly ICallLimiterService? _callLimitService;

    private readonly TBotOptions _botOptions;
    private readonly CallLimiterOptions? _limitConfig;

    public TBotClient(
        ILogger<ITBotClient>? logger,
        IOptions<TBotOptions> botOptions,
        IRequestService requestService, 
        IOptions<CallLimiterOptions>? limitConfig = null,
        ICallLimiterService? callLimitService = null)
    {
        _logger = logger;
        _botOptions = botOptions.Value;
        _limitConfig = limitConfig?.Value;
        _requestService = requestService;
        _callLimitService = callLimitService;
    }

    public Task<Response<List<Message>>> SendMediaGroupAsync(SendMediaGroupOptions options)
    {
        var request = RequestDescriptor.CreatePost("/sendMediaGroup", options);
        return SendAsync<List<Message>, List<MessageDto>>(request, 
            dtoList => dtoList.Select(Converter.ToDomain).ToList());
    }
    
    public Task<Response<Message>> SendPhotoAsync(SendVideoOptions options)
    {
        return SendBaseRequestAsync("/sendPhoto", options);
    }
    
    public Task<Response<Message>> SendVideoAsync(SendVideoOptions options)
    {
        return SendBaseRequestAsync("/sendVideo", options);
    }

    public Task<Response<bool>> DeleteMessagesAsync(DeleteMessagesOptions options)
    {
        var request = RequestDescriptor.CreatePost("/deleteMessages", options);
        return SendAsync<bool, bool>(request, b => b);
    }
    
    public Task<Response<bool>> DeleteMessageAsync(DeleteMessageOptions options)
    {
        var request = RequestDescriptor.CreatePost("/deleteMessage", options);
        return SendAsync<bool, bool>(request, b => b);
    }
    
    public Task<Response<Message>> SendMessageAsync(SendMessageOptions options)
    {
        return SendBaseRequestAsync("/sendMessage", options);
    }

    private Task<Response<Message>> SendBaseRequestAsync(string endpoint, BaseOptions options)
    {
        var request = RequestDescriptor.CreatePost(endpoint, options);
        return SendAsync<Message, MessageDto>(request, Converter.ToDomain);
    }
    
    public Task<Response<List<Update>>> GetUpdateAsync(GetUpdateOptions options)
    {
        var request = RequestDescriptor.CreatePost("/getUpdates", options);
        return SendAsync<List<Update>, List<UpdateDto>>(request, 
            dtoList => dtoList.Select(Converter.ToDomain).ToList());
    }
    
    public async Task<Response<TResponseDomain>> SendAsync<TResponseDomain, TResponseDto>(
        RequestDescriptor request, Func<TResponseDto, TResponseDomain> convertor)
    {
        _logger?.LogDebug("Request execution started. Method: {HttpMethod}. Endpoint: {Endpoint}.", 
            request.Method, request.Endpoint);

        var watch = Stopwatch.StartNew();
        var response = await SendAsync(request);
        
        var responseSteam = await response.Content.ReadAsStreamAsync();
        var responseDto = await JsonSerializer.DeserializeAsync<ResponseDto<TResponseDto>>(responseSteam);

        watch.Stop();
        _logger?.LogDebug(
            "Request completed. StatusCode: {StatusCode}. Time: {} ms. Description: {Description}",
            response.StatusCode, watch.ElapsedMilliseconds, responseDto?.Description);
        
        if (responseDto is null) {
            throw new Exception($"Couldn't deserialize an response dto. RequestBody: {response.Content.ReadAsStringAsync()}");
        }

        return Response<TResponseDomain>.Create(
            responseDto.StatusOk,
            responseDto.Result is null ? default : convertor(responseDto.Result!),
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