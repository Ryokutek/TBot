using Newtonsoft.Json;
using TBot.Core.RequestOptions.ReplyMarkupParameters.Buttons;

namespace TBot.Core.RequestOptions.ReplyMarkupParameters.Keyboards;

public class ReplyKeyboardMarkup : Keyboard<KeyboardButton>
{
    [JsonProperty("keyboard", Required = Required.Always)]
    protected override List<List<KeyboardButton>> Buttons { get; set; } = new ();
    
    [JsonProperty("is_persistent", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool IsPersistent { get; set; }
    
    [JsonProperty("resize_keyboard", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool ResizeKeyboard { get; set; }
    
    [JsonProperty("one_time_keyboard", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool OneTimeKeyboard { get; set; }
    
    [JsonProperty("input_field_placeholder", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string InputFieldPlaceholder { get; set; } = null!;
    
    [JsonProperty("selective", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool Selective { get; set; }
}