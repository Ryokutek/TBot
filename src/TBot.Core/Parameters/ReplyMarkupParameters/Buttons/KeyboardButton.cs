using Newtonsoft.Json;
using TBot.Core.Parameters.ReplyMarkupParameters.Buttons.RequestButtonParameter;

namespace TBot.Core.Parameters.ReplyMarkupParameters.Buttons;

public class KeyboardButton : Button
{
    [JsonProperty("request_user", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public KeyboardButtonRequestUser? RequestUser { get; set; }
    
    [JsonProperty("request_chat", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public KeyboardButtonRequestChat? RequestChat { get; set; }
    
    [JsonProperty("request_contact", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? RequestContact { get; set; }
    
    [JsonProperty("request_location", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? RequestLocation { get; set; }
    
    [JsonProperty("request_poll", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public KeyboardButtonPollType? RequestPoll { get; set; }
    
    //TODO: 1.0
    /*[Parameter("web_app")]
    public WebApp? WebApp { get; set; }*/
}