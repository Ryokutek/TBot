using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace TBot.Telegram.Dto.Responses;

public class ResponseDto
{
    [JsonPropertyName("ok")]
    public bool StatusOk { get; set; }
    
    [JsonPropertyName("result")]
    public JToken? Result { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("error_code")]
    public int? ErrorCode { get; set; }
    
    [JsonPropertyName("parameters")]
    public ResponseParametersDto? ResponseParameters { get; set; }
}