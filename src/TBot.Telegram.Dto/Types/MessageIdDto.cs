using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represents a unique message identifier.
/// </summary>
public class MessageIdDto
{
	/// <summary>
	/// Unique message identifier
	/// </summary>
	[JsonPropertyName("message_id")]
	public int MessageId { get; set; }
}