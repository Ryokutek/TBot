using Newtonsoft.Json;

namespace TBot.Core.RequestOptions.Reply.MarkumParameters;

public class ReplyKeyboardRemove : ReplyMarkup
{
    [JsonProperty("remove_keyboard", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool RemoveKeyboard { get; set; }
    
    [JsonProperty("selective", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool Selective { get; set; }
}