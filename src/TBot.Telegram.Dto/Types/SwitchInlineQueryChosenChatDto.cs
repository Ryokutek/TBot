using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represents an inline button that switches the current user to inline mode in a chosen chat, with an optional default inline query.
/// </summary>
public class SwitchInlineQueryChosenChatDto
{
	/// <summary>
	/// Optional. The default inline query to be inserted in the input field. If left empty, only the bot's username will be inserted
	/// </summary>
	[JsonPropertyName("query")]
	public string? Query { get; set; }

	/// <summary>
	/// Optional. True, if private chats with users can be chosen
	/// </summary>
	[JsonPropertyName("allow_user_chats")]
	public bool? AllowUserChats { get; set; }

	/// <summary>
	/// Optional. True, if private chats with bots can be chosen
	/// </summary>
	[JsonPropertyName("allow_bot_chats")]
	public bool? AllowBotChats { get; set; }

	/// <summary>
	/// Optional. True, if group and supergroup chats can be chosen
	/// </summary>
	[JsonPropertyName("allow_group_chats")]
	public bool? AllowGroupChats { get; set; }

	/// <summary>
	/// Optional. True, if channel chats can be chosen
	/// </summary>
	[JsonPropertyName("allow_channel_chats")]
	public bool? AllowChannelChats { get; set; }
}