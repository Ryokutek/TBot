using Newtonsoft.Json;

namespace TBot.Core.RequestOptions.Reply.MarkumParameters.Buttons;

public class Button
{
    [JsonProperty("text", Required = Required.Always)]
    public string Text { get; set; } = null!;
}