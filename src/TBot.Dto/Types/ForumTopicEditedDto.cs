using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents a service message about a forum topic closed in the chat. Currently holds no information.
/// </summary>
public abstract class ForumTopicEditedDto
{
    /// <summary>
    /// New name of the topic, if it was edited
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// New identifier of the custom emoji shown as the topic icon, if it was edited; an empty string if the icon was removed
    /// </summary>
    [JsonPropertyName("icon_custom_emoji_id")]
    public string? IconCustomEmojiId { get; set; }
}