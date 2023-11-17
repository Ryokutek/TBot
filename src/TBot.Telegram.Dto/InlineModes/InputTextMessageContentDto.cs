using System.Collections.Generic;
using System.Text.Json.Serialization;
using TBot.Telegram.Dto.Types;

namespace TBot.Telegram.Dto.InlineModes;

/// <summary>
/// Represents the content of a text message to be sent as the result of an inline query.
/// </summary>
public class InputTextMessageContentDto
{
	/// <summary>
	/// Text of the message to be sent, 1-4096 characters
	/// </summary>
	[JsonPropertyName("message_text")]
	public string MessageText { get; set; } = null!;

	/// <summary>
	/// Optional. Mode for parsing entities in the message text. See formatting options for more details.
	/// </summary>
	[JsonPropertyName("parse_mode")]
	public string? ParseMode { get; set; }

	/// <summary>
	/// Optional. List of special entities that appear in message text, which can be specified instead of parse_mode
	/// </summary>
	[JsonPropertyName("entities")]
	public List<MessageEntityDto>? Entities { get; set; }

	/// <summary>
	/// Optional. Disables link previews for links in the sent message
	/// </summary>
	[JsonPropertyName("disable_web_page_preview")]
	public bool? DisableWebPagePreview { get; set; }
}