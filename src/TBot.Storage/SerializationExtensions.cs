using Newtonsoft.Json;

namespace TBot.Storage;

public static class SerializationExtensions
{
    internal static T? ToObject<T>(this string? value)
    {
        return string.IsNullOrEmpty(value) ? default : JsonConvert.DeserializeObject<T>(value);
    }
    
    internal static string ToJson<T>(this T? value)
    {
        return JsonConvert.SerializeObject(value);
    }
}