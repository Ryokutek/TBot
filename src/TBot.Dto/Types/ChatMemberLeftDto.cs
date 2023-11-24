using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Represents a chat member that isn't currently a member of the chat, but may join it themselves.
/// </summary>
public class ChatMemberLeftDto
{
	/// <summary>
	/// The member's status in the chat, always “left”
	/// </summary>
	[JsonPropertyName("status")]
	public string Status { get; set; } = null!;

	/// <summary>
	/// Information about the user
	/// </summary>
	[JsonPropertyName("user")]
	public UserDto User { get; set; } = null!;
}