using Newtonsoft.Json;
using TBot.Dto.Types;

namespace TBot.Core.RequestOptions.Inputs.Media;

public abstract class InputMedia
{
    [JsonProperty("type", Required = Required.Always)]
    public abstract string Type { get; }
    
    [JsonConverter(typeof(MediaAttachConverter))]
    [JsonProperty("media", Required = Required.Always)]
    public MediaAttach Media { get; set; } = null!;
    
    [JsonProperty("caption", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Caption { get; set; }
    
    [JsonProperty("parse_mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ParseMode ParseMode { get; set; }
    
    [JsonProperty("caption_entities", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<MessageEntityDto>? CaptionEntities { get; set; }
}