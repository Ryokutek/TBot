using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// Represents a chat member that has no additional privileges or restrictions.
/// </summary>
public class ChatMemberMemberDto
{
	/// <summary>
	/// The member's status in the chat, always “member”
	/// </summary>
	[JsonPropertyName("status")]
	public string Status { get; set; } = null!;

	/// <summary>
	/// Information about the user
	/// </summary>
	[JsonPropertyName("user")]
	public UserDto User { get; set; } = null!;
}