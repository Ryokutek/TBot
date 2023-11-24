using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TBot.Client.Utilities;

internal static class SerializationExtensions
{
    internal static T? ToObject<T>(this string? value)
    {
        return string.IsNullOrEmpty(value) ? default : JsonConvert.DeserializeObject<T>(value);
    }
    
    internal static async Task<T?> DeserializeAsync<T>(this object value)
    {
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(value.ToString()!));
        return await JsonSerializer.DeserializeAsync<T>(stream);
    }
    
    internal static async Task<T?> DeserializeAsync<T>(this HttpResponseMessage responseMessage)
    {
        var responseStream = await responseMessage.Content.ReadAsStreamAsync();
        return await responseStream.DeserializeAsync<T>();
    }
    
    private static async Task<T?> DeserializeAsync<T>(this Stream stream)
    {
        return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions());
    }
    
    internal static string ToJson<T>(this T? value)
    {
        return JsonConvert.SerializeObject(value);
    }
}