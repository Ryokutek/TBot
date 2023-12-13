namespace TBot.Core.HttpRequests.Models;

public class Content
{
    public string Name { get; set; } = null!;
    public string MediaType { get; set; } = null!;
    public object Value { get; set; } = null!;
}