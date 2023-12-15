using Newtonsoft.Json;

namespace TBot.Core.RequestOptions.Inputs.Media;

public class InputMediaVideo : InputMedia
{
    public override string Type => "video";
    
    [JsonConverter(typeof(MediaAttachConverter))]
    [JsonProperty("thumbnail", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MediaAttach? Thumbnail { get; set; }
    
    [JsonProperty("width", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Width { get; set; }
    
    [JsonProperty("height", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Height { get; set; }
    
    [JsonProperty("duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Duration { get; set; }
    
    [JsonProperty("supports_streaming", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool SupportsStreaming { get; set; }
    
    [JsonProperty("has_spoiler", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool HasSpoiler { get; set; }
}