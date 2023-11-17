using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represents a service message about a new forum topic created in the chat.
/// </summary>
public class ForumTopicCreatedDto
{
	/// <summary>
	/// Name of the topic
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = null!;

	/// <summary>
	/// Color of the topic icon in RGB format
	/// </summary>
	[JsonPropertyName("icon_color")]
	public int IconColor { get; set; }

	/// <summary>
	/// Optional. Unique identifier of the custom emoji shown as the topic icon
	/// </summary>
	[JsonPropertyName("icon_custom_emoji_id")]
	public string? IconCustomEmojiId { get; set; }
}