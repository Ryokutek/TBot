using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// Represents a menu button, which opens the bot's list of commands.
/// </summary>
public class MenuButtonCommandsDto
{
	/// <summary>
	/// Type of the button, must be commands
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;
}