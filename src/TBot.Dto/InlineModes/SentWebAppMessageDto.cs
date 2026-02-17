using System.Text.Json.Serialization;

namespace TBot.Dto.InlineModes;

/// <summary>
/// Describes an inline message sent by a Web App on behalf of a user.
/// </summary>
public class SentWebAppMessageDto
{
	/// <summary>
	/// Optional. Identifier of the sent inline message. Available only if there is an inline keyboard attached to the message.
	/// </summary>
	[JsonPropertyName("inline_message_id")]
	public string? InlineMessageId { get; set; }
}