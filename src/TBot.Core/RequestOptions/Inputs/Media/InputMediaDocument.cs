using Newtonsoft.Json;

namespace TBot.Core.RequestOptions.Inputs.Media;

public class InputMediaDocument : InputMedia
{
    public override string Type => "document";
    
    [JsonConverter(typeof(MediaAttachConverter))]
    [JsonProperty("thumbnail", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MediaAttach? Thumbnail { get; set; }
    
    [JsonProperty("disable_content_type_detection", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? DisableContentTypeDetection { get; set; }
}