using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents a service message about a change in auto-delete timer settings.
/// </summary>
public class MessageAutoDeleteTimerChangedDto
{
	/// <summary>
	/// New auto-delete time for messages in the chat; in seconds
	/// </summary>
	[JsonPropertyName("message_auto_delete_time")]
	public int MessageAutoDeleteTime { get; set; }
}