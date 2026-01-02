using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Describes data sent from a Web App to the bot.
/// </summary>
public abstract class WebAppDataDto
{
	/// <summary>
	/// The data. Be aware that a bad client can send arbitrary data in this field.
	/// </summary>
	[JsonPropertyName("data")]
	public string Data { get; set; } = null!;

	/// <summary>
	/// Text of the web_app keyboard button from which the Web App was opened. Be aware that a bad client can send arbitrary data in this field.
	/// </summary>
	[JsonPropertyName("button_text")]
	public string ButtonText { get; set; } = null!;
}