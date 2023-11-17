using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represents the content of a service message, sent whenever a user in the chat triggers a proximity alert set by another user.
/// </summary>
public class ProximityAlertTriggeredDto
{
	/// <summary>
	/// User that triggered the alert
	/// </summary>
	[JsonPropertyName("traveler")]
	public UserDto Traveler { get; set; } = null!;

	/// <summary>
	/// User that set the alert
	/// </summary>
	[JsonPropertyName("watcher")]
	public UserDto Watcher { get; set; } = null!;

	/// <summary>
	/// The distance between the users
	/// </summary>
	[JsonPropertyName("distance")]
	public int Distance { get; set; }
}