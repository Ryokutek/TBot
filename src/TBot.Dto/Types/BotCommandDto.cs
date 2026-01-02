using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents a bot command.
/// </summary>
public abstract class BotCommandDto
{
	/// <summary>
	/// Text of the command; 1-32 characters. Can contain only lowercase English letters, digits and underscores.
	/// </summary>
	[JsonPropertyName("command")]
	public string Command { get; set; } = null!;

	/// <summary>
	/// Description of the command; 1-256 characters.
	/// </summary>
	[JsonPropertyName("description")]
	public string Description { get; set; } = null!;
}