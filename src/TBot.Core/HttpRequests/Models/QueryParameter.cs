namespace TBot.Core.HttpRequests.Models;

public class QueryParameter
{
    public string Key { get; }
    public object? Value { get; }
        
    public QueryParameter(string key, object? value)
    {
        Key = key;
        Value = value;
    }
}