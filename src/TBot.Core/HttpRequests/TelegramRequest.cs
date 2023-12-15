using TBot.Core.TBot;

namespace TBot.Core.HttpRequests;

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

        if (_requestDescriptor.Contents.Any()) {
            httpRequestMessage.Content = BuildHttpContent();
        }

        uriBuilder.Query = string.Join("&", _requestDescriptor.QueryParameters
            .Select(x => $"{x.Key}={x.Value}"));
        
        httpRequestMessage.RequestUri = new Uri(uriBuilder.Uri.AbsoluteUri);
        httpRequestMessage.Method = _requestDescriptor.Method;
        return httpRequestMessage;
    }

    private HttpContent BuildHttpContent()
    {
        var multipartFormDataContent = new MultipartFormDataContent();
        foreach (var content in _requestDescriptor.Contents)
        {
            switch (content.MediaType)
            {
                case ContentHeaders.MultipartFormData:
                    multipartFormDataContent.Add(new StreamContent((Stream)content.Value), content.Name, $"TBot.{Guid.NewGuid()}");
                    break;
                case ContentHeaders.TextPlain:
                    multipartFormDataContent.Add(new StringContent((content.Value as string)!), content.Name);
                    break;
            }
        }

        return multipartFormDataContent;
    }
}