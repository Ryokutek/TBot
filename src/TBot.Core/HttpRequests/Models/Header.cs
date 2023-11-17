namespace TBot.Core.HttpRequests.Models;

public class Header
{
    public string Key { get; }
    public string Value { get; }
        
    public Header(string key, string value)
    {
        Key = key;
        Value = value;
    }
}