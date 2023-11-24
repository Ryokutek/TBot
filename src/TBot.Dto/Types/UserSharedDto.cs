using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object contains information about the user whose identifier was shared with the bot using a KeyboardButtonRequestUser button.
/// </summary>
public class UserSharedDto
{
    /// <summary>
    /// Identifier of the request
    /// </summary>
    [JsonPropertyName("request_id")]
    public int RequestId { get; set; }

    /// <summary>
    /// Identifier of the shared user. This number may have more than 32 significant bits and some programming
    /// languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits,
    /// so a 64-bit integer or double-precision float type are safe for storing this identifier. The bot may not
    /// have access to the user and could be unable to use this identifier, unless the user is already known to the
    /// bot by some other means.
    /// </summary>
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
}