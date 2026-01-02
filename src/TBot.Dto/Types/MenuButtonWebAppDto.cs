using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Represents a menu button, which launches a Web App.
/// </summary>
public abstract class MenuButtonWebAppDto
{
	/// <summary>
	/// Type of the button, must be web_app
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Text on the button
	/// </summary>
	[JsonPropertyName("text")]
	public string Text { get; set; } = null!;

	/// <summary>
	/// Description of the Web App that will be launched when the user presses the button. The Web App will be able to send an arbitrary message on behalf of the user using the method answerWebAppQuery.
	/// </summary>
	[JsonPropertyName("web_app")]
	public WebAppInfoDto WebApp { get; set; } = null!;
}