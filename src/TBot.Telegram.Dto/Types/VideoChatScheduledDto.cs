using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represents a service message about a video chat scheduled in the chat.
/// </summary>
public class VideoChatScheduledDto
{
	/// <summary>
	/// Point in time (Unix timestamp) when the video chat is supposed to be started by a chat administrator
	/// </summary>
	[JsonPropertyName("start_date")]
	public int StartDate { get; set; }
}