using Newtonsoft.Json;

namespace TBot.Core.Parameters.ReplyMarkupParameters.Buttons;

public class InlineKeyboardButton : Button
{
    [JsonProperty("url", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Url { get; set; } = null!;
    
    [JsonProperty("callback_data", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string CallbackData { get; set; } = null!;
    
    //TODO: 1.0+
    /*[Parameter("web_app")]
    public WebApp WebApp { get; set; } = null!;*/
    
    //TODO: 1.0+
    /*[Parameter("login_url")]
    public LoginUrl LoginUrl { get; set; } = null!;*/
    
    [JsonProperty("switch_inline_query", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string SwitchInlineQuery { get; set; } = null!;
    
    [JsonProperty("switch_inline_query_current_chat", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string SwitchInlineQueryCurrentChat { get; set; } = null!;
    
    //TODO: 1.0+
    /*[Parameter("callback_game")]
    public CallbackGame callback_game { get; set; } = null!;*/
    
    [JsonProperty("pay", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool Pay { get; set; }
}