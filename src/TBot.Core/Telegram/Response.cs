namespace TBot.Core.Telegram;

public class Response<TResult>
{
    public bool StatusOk { get; private set; }
    public TResult Result { get; private set; }
    public string? Description { get; private set; }
    public int? ErrorCode { get; private set; }
    public ResponseParameters? ResponseParameters { get; private set; }

    private Response(
        bool statusOk,
        TResult result, 
        string? description, 
        int? errorCode, 
        ResponseParameters? responseParameters)
    {
        StatusOk = statusOk;
        Result = result;
        Description = description;
        ErrorCode = errorCode;
        ResponseParameters = responseParameters;
    }
    
    public static Response<T> Create<T>(
        bool statusOk,
        T? result, 
        string? description, 
        int? errorCode, 
        ResponseParameters? responseParameters) where T : new()
    {
        return new Response<T>(statusOk, result ?? new T(), description, errorCode, responseParameters);
    }
}