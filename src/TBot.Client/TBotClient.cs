using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TBot.Core.CallLimiter.Interfaces;
using TBot.Core.ConfigureOptions;
using TBot.Core.RequestManagement;
using TBot.Core.RequestManagement.Interfaces;
using TBot.Core.RequestOptions;
using TBot.Core.RequestOptions.Structure;
using TBot.Core.TBot.Interfaces;
using TBot.Dto.Responses;
using TBot.Dto.Types;
using TBot.Dto.Updates;

namespace TBot.Client;

// ReSharper disable once InconsistentNaming
public class TBotClient(
    ILogger<ITBotClient>? logger,
    IOptions<TBotOptions> botOptions,
    IRequestService requestService,
    IOptions<CallLimiterOptions>? limitConfig = null,
    ICallLimiterService? callLimitService = null) : ITBotClient
{
    private readonly TBotOptions _botOptions = botOptions.Value;
    private readonly CallLimiterOptions? _limitConfig = limitConfig?.Value;

    public Task<ResponseDto<List<MessageDto>>> SendMediaGroupAsync(SendMediaGroupOptions options)
    {
        var request = RequestDescriptor.CreatePost("/sendMediaGroup", options);
        return SendAsync<List<MessageDto>>(request);
    }
    
    public Task<ResponseDto<MessageDto>> SendPhotoAsync(SendVideoOptions options)
    {
        return SendBaseRequestAsync("/sendPhoto", options);
    }
    
    public Task<ResponseDto<MessageDto>> SendVideoAsync(SendVideoOptions options)
    {
        return SendBaseRequestAsync("/sendVideo", options);
    }

    public Task<ResponseDto<bool>> DeleteMessagesAsync(DeleteMessagesOptions options)
    {
        var request = RequestDescriptor.CreatePost("/deleteMessages", options);
        return SendAsync<bool>(request);
    }
    
    public Task<ResponseDto<bool>> DeleteMessageAsync(DeleteMessageOptions options)
    {
        var request = RequestDescriptor.CreatePost("/deleteMessage", options);
        return SendAsync<bool>(request);
    }
    
    public Task<ResponseDto<MessageDto>> SendMessageAsync(SendMessageOptions options)
    {
        return SendBaseRequestAsync("/sendMessage", options);
    }

    private Task<ResponseDto<MessageDto>> SendBaseRequestAsync(string endpoint, BaseOptions options)
    {
        var request = RequestDescriptor.CreatePost(endpoint, options);
        return SendAsync<MessageDto>(request);
    }
    
    public Task<ResponseDto<List<UpdateDto>>> GetUpdateAsync(GetUpdateOptions options)
    {
        var request = RequestDescriptor.CreatePost("/getUpdates", options);
        return SendAsync<List<UpdateDto>>(request);
    }
    
    public async Task<ResponseDto<TResponseDto>> SendAsync<TResponseDto>(RequestDescriptor request)
    {
        logger?.LogDebug("Request execution started. Method: {HttpMethod}. Endpoint: {Endpoint}.", 
            request.Method, request.Endpoint);

        var watch = Stopwatch.StartNew();
        var response = await SendAsync(request);
        
        var responseSteam = await response.Content.ReadAsStreamAsync();
        var responseDto = await JsonSerializer.DeserializeAsync<ResponseDto<TResponseDto>>(responseSteam);

        watch.Stop();
        logger?.LogDebug(
            "Request completed. StatusCode: {StatusCode}. Time: {ElapsedMilliseconds} ms. Description: {Description}.",
            response.StatusCode, watch.ElapsedMilliseconds, responseDto?.Description);
        
        return responseDto ?? throw new Exception($"Couldn't deserialize an response dto. RequestBody: {response.Content.ReadAsStringAsync()}");
    }

    public async Task<HttpResponseMessage> SendAsync(RequestDescriptor request)
    {
        var telegramRequest = TelegramRequest.Create(_botOptions.Token, request);
        
        if (callLimitService is not null && !string.IsNullOrEmpty(telegramRequest.ChatId)) {
            await callLimitService.WaitAsync(telegramRequest.ChatId, telegramRequest.MessageCount, _limitConfig!); 
        }

        return await requestService.SendAsync(telegramRequest.Build());
    }
}