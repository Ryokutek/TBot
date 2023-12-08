﻿namespace TBot.Core.HttpRequests;

public class TelegramRequest
{
    private readonly string _token;
    private const string ApiUrl = "https://api.telegram.org";
    private const string ChatIdParameterName = "chat_id";
    
    private static string GetBaseUrl (string token) => $"{ApiUrl}/bot{token}";
    private readonly RequestDescriptor _requestDescriptor;

    public string ChatId { get; private set; } = string.Empty;

    private TelegramRequest(string token, RequestDescriptor requestDescriptor)
    {
        _token = token;
        _requestDescriptor = requestDescriptor;
        
        var chatIdParameter = requestDescriptor.QueryParameters.FirstOrDefault(x => x.Key == ChatIdParameterName);
        if (chatIdParameter is not null) {
            ChatId = chatIdParameter.Value!.ToString()!;
        }
    }

    public static TelegramRequest Create(string token, RequestDescriptor requestDescriptor)
    {
        return new TelegramRequest(token, requestDescriptor);
    }
    
    public HttpRequestMessage Build()
    {
        var httpRequestMessage = new HttpRequestMessage();
        var uriBuilder = new UriBuilder(GetBaseUrl(_token) + _requestDescriptor.Endpoint);
        
        foreach (var parameter in _requestDescriptor.Headers)
        {
            httpRequestMessage.Headers.TryAddWithoutValidation(parameter.Key, parameter.Value);
        }

        HttpContent? httpContent = default;
        foreach (var content in _requestDescriptor.Contents)
        {
            if (content.MediaType != "multipart/form-data") {
                continue;
            }
            
            var multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(new StreamContent((Stream)content.Value), "video", $"TBot:{Guid.NewGuid()}");
            httpContent = multipartFormDataContent;
        }

        uriBuilder.Query = string.Join("&", _requestDescriptor.QueryParameters.Select(x => $"{x.Key}={x.Value}"));
        httpRequestMessage.RequestUri = new Uri(uriBuilder.Uri.AbsoluteUri);
        httpRequestMessage.Method = _requestDescriptor.Method;
        if (httpContent is not null) {
            httpRequestMessage.Content = httpContent;
        }
        
        return httpRequestMessage;
    }
}