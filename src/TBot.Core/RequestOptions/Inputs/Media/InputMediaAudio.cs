using Newtonsoft.Json;

namespace TBot.Core.RequestOptions.Inputs.Media;

public class InputMediaAudio : InputMedia
{
    public override string Type => "audio";
    
    [JsonConverter(typeof(MediaAttachConverter))]
    [JsonProperty("thumbnail", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MediaAttach? Thumbnail { get; set; }
    
    [JsonProperty("duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Duration { get; set; }
    
    [JsonProperty("performer", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Performer { get; set;}
    
    [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Title { get; set;}
}