using TBot.Core.Telegram;

namespace TBot.Core.HttpResponse;

public class Result<TResponse>
{
    public Response<TResponse> Response { get; private set; }
    public HttpResponseMessage HttpResponse { get; private set; }
    
    private Result(Response<TResponse> response, HttpResponseMessage httpResponse)
    {
        Response = response;
        HttpResponse = httpResponse;
    }

    public static Result<TResponse> Create(Response<TResponse> response, HttpResponseMessage httpResponse)
    {
        return new Result<TResponse>(response, httpResponse);
    }
}