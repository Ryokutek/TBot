using System.Text.Json.Serialization;

namespace TBot.Dto.Responses;

public class ResponseDto<TResultDto>
{
    [JsonPropertyName("ok")]
    public bool StatusOk { get; set; }
    
    [JsonPropertyName("result")]
    public TResultDto? Result { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("error_code")]
    public int? ErrorCode { get; set; }
    
    [JsonPropertyName("parameters")]
    public ResponseParametersDto? ResponseParameters { get; set; }
}