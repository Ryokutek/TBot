using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents a forum topic.
/// </summary>
public abstract class ForumTopicDto
{
	/// <summary>
	/// Unique identifier of the forum topic
	/// </summary>
	[JsonPropertyName("message_thread_id")]
	public int MessageThreadId { get; set; }

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