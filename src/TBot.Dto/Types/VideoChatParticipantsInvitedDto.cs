using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents a service message about new members invited to a video chat.
/// </summary>
public class VideoChatParticipantsInvitedDto
{
	/// <summary>
	/// New members that were invited to the video chat
	/// </summary>
	[JsonPropertyName("users")]
	public List<UserDto> Users { get; set; } = null!;
}