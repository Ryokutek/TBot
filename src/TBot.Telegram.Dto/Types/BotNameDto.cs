using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represents the bot's name.
/// </summary>
public class BotNameDto
{
	/// <summary>
	/// The bot's name
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = null!;
}