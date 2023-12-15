using Newtonsoft.Json;

namespace TBot.Core.RequestOptions.Inputs.Media;

public class InputMediaPhoto : InputMedia
{
    public override string Type => "photo";
    
    [JsonProperty("has_spoiler", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool HasSpoiler { get; set; }
}