using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Represents a chat member that was banned in the chat and can't return to the chat or view chat messages.
/// </summary>
public class ChatMemberBannedDto
{
	/// <summary>
	/// The member's status in the chat, always “kicked”
	/// </summary>
	[JsonPropertyName("status")]
	public string Status { get; set; } = null!;

	/// <summary>
	/// Information about the user
	/// </summary>
	[JsonPropertyName("user")]
	public UserDto User { get; set; } = null!;

	/// <summary>
	/// Date when restrictions will be lifted for this user; unix time. If 0, then the user is banned forever
	/// </summary>
	[JsonPropertyName("until_date")]
	public int UntilDate { get; set; }
}