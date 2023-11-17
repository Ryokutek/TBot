using Newtonsoft.Json;

namespace TBot.Core.Parameters.ReplyMarkupParameters.Buttons;

public class Button
{
    [JsonProperty("text", Required = Required.Always)]
    public string Text { get; set; } = null!;
}