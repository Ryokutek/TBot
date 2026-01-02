using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents a service message about a user allowing a bot to write messages after adding the bot to the attachment menu or launching a Web App from a link.
/// </summary>
public abstract class WriteAccessAllowedDto
{
	/// <summary>
	/// Optional. Name of the Web App which was launched from a link
	/// </summary>
	[JsonPropertyName("web_app_name")]
	public string? WebAppName { get; set; }
}