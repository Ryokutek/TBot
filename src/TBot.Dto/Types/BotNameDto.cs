using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents the bot's name.
/// </summary>
public abstract class BotNameDto
{
	/// <summary>
	/// The bot's name
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = null!;
}