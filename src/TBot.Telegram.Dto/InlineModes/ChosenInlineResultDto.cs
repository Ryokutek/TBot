using System.Text.Json.Serialization;
using TBot.Telegram.Dto.Types;

namespace TBot.Telegram.Dto.InlineModes;

/// <summary>
/// Represents a result of an inline query that was chosen by the user and sent to their chat partner.
/// </summary>
public class ChosenInlineResultDto
{
	/// <summary>
	/// The unique identifier for the result that was chosen
	/// </summary>
	[JsonPropertyName("result_id")]
	public string ResultId { get; set; } = null!;

	/// <summary>
	/// The user that chose the result
	/// </summary>
	[JsonPropertyName("from")]
	public UserDto From { get; set; } = null!;

	/// <summary>
	/// Optional. Sender location, only for bots that require user location
	/// </summary>
	[JsonPropertyName("location")]
	public LocationDto? Location { get; set; }

	/// <summary>
	/// Optional. Identifier of the sent inline message. Available only if there is an inline keyboard attached to the message. Will be also received in callback queries and can be used to edit the message.
	/// </summary>
	[JsonPropertyName("inline_message_id")]
	public string? InlineMessageId { get; set; }

	/// <summary>
	/// The query that was used to obtain the result
	/// </summary>
	[JsonPropertyName("query")]
	public string Query { get; set; } = null!;
}