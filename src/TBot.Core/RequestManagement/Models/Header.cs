namespace TBot.Core.RequestManagement.Models;

public abstract class Header(string key, string value)
{
    public string Key { get; } = key;
    public string Value { get; } = value;
}