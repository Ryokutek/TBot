using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents the bot's short description.
/// </summary>
public class BotShortDescriptionDto
{
	/// <summary>
	/// The bot's short description
	/// </summary>
	[JsonPropertyName("short_description")]
	public string ShortDescription { get; set; } = null!;
}