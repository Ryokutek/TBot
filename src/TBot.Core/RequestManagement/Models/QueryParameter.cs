namespace TBot.Core.RequestManagement.Models;

public class QueryParameter(string key, object? value)
{
    public string Key { get; } = key;
    public object? Value { get; } = value;
}