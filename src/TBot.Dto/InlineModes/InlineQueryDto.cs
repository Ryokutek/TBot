using System.Text.Json.Serialization;
using TBot.Dto.Types;

namespace TBot.Dto.InlineModes;

/// <summary>
/// This object represents an incoming inline query. When the user sends an empty query, your bot could return some default or trending results.
/// </summary>
public abstract class InlineQueryDto
{
	/// <summary>
	/// Unique identifier for this query
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = null!;

	/// <summary>
	/// Sender
	/// </summary>
	[JsonPropertyName("from")]
	public UserDto From { get; set; } = null!;

	/// <summary>
	/// Text of the query (up to 256 characters)
	/// </summary>
	[JsonPropertyName("query")]
	public string Query { get; set; } = null!;

	/// <summary>
	/// Offset of the results to be returned, can be controlled by the bot
	/// </summary>
	[JsonPropertyName("offset")]
	public string Offset { get; set; } = null!;

	/// <summary>
	/// Optional. Type of the chat from which the inline query was sent. Can be either “sender” for a private chat with the inline query sender, “private”, “group”, “supergroup”, or “channel”. The chat type should be always known for requests sent from official clients and most third-party clients, unless the request was sent from a secret chat
	/// </summary>
	[JsonPropertyName("chat_type")]
	public string? ChatType { get; set; }

	/// <summary>
	/// Optional. Sender location, only for bots that request user location
	/// </summary>
	[JsonPropertyName("location")]
	public LocationDto? Location { get; set; }
}