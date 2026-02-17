using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Represents a chat member that owns the chat and has all administrator privileges.
/// </summary>
public class ChatMemberOwnerDto
{
	/// <summary>
	/// The member's status in the chat, always “creator”
	/// </summary>
	[JsonPropertyName("status")]
	public string Status { get; set; } = null!;

	/// <summary>
	/// Information about the user
	/// </summary>
	[JsonPropertyName("user")]
	public UserDto User { get; set; } = null!;

	/// <summary>
	/// True, if the user's presence in the chat is hidden
	/// </summary>
	[JsonPropertyName("is_anonymous")]
	public bool IsAnonymous { get; set; }

	/// <summary>
	/// Optional. Custom title for this user
	/// </summary>
	[JsonPropertyName("custom_title")]
	public string? CustomTitle { get; set; }
}