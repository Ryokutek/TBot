using Newtonsoft.Json;

namespace TBot.Core.Parameters.ReplyMarkupParameters;

public class ForceReply : ReplyMarkup
{
    [JsonProperty("force_reply", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool IsForceReply { get; set; }

    [JsonProperty("input_field_placeholder", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string InputFieldPlaceholder { get; set; } = null!;
    
    [JsonProperty("selective", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool Selective { get; set; }
}