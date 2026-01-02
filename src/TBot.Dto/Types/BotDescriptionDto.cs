using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents the bot's description.
/// </summary>
public abstract class BotDescriptionDto
{
	/// <summary>
	/// The bot's description
	/// </summary>
	[JsonPropertyName("description")]
	public string Description { get; set; } = null!;
}