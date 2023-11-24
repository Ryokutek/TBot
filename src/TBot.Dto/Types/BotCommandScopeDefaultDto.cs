using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Represents the default scope of bot commands. Default commands are used if no commands with a narrower scope are specified for the user.
/// </summary>
public class BotCommandScopeDefaultDto
{
	/// <summary>
	/// Scope type, must be default
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;
}