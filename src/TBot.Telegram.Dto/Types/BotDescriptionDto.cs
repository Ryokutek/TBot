using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represents the bot's description.
/// </summary>
public class BotDescriptionDto
{
	/// <summary>
	/// The bot's description
	/// </summary>
	[JsonPropertyName("description")]
	public string Description { get; set; } = null!;
}