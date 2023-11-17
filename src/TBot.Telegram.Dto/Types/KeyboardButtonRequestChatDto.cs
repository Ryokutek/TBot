using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object defines the criteria used to request a suitable chat. The identifier of the selected chat will be shared with the bot when the corresponding button is pressed. More about requesting chats »
/// </summary>
public class KeyboardButtonRequestChatDto
{
	/// <summary>
	/// Signed 32-bit identifier of the request, which will be received back in the ChatShared object. Must be unique within the message
	/// </summary>
	[JsonPropertyName("request_id")]
	public int RequestId { get; set; }

	/// <summary>
	/// Pass True to request a channel chat, pass False to request a group or a supergroup chat.
	/// </summary>
	[JsonPropertyName("chat_is_channel")]
	public bool ChatIsChannel { get; set; }

	/// <summary>
	/// Optional. Pass True to request a forum supergroup, pass False to request a non-forum chat. If not specified, no additional restrictions are applied.
	/// </summary>
	[JsonPropertyName("chat_is_forum")]
	public bool? ChatIsForum { get; set; }

	/// <summary>
	/// Optional. Pass True to request a supergroup or a channel with a username, pass False to request a chat without a username. If not specified, no additional restrictions are applied.
	/// </summary>
	[JsonPropertyName("chat_has_username")]
	public bool? ChatHasUsername { get; set; }

	/// <summary>
	/// Optional. Pass True to request a chat owned by the user. Otherwise, no additional restrictions are applied.
	/// </summary>
	[JsonPropertyName("chat_is_created")]
	public bool? ChatIsCreated { get; set; }

	/// <summary>
	/// Optional. A JSON-serialized object listing the required administrator rights of the user in the chat. The rights must be a superset of bot_administrator_rights. If not specified, no additional restrictions are applied.
	/// </summary>
	[JsonPropertyName("user_administrator_rights")]
	public ChatAdministratorRightsDto? UserAdministratorRights { get; set; }

	/// <summary>
	/// Optional. A JSON-serialized object listing the required administrator rights of the bot in the chat. The rights must be a subset of user_administrator_rights. If not specified, no additional restrictions are applied.
	/// </summary>
	[JsonPropertyName("bot_administrator_rights")]
	public ChatAdministratorRightsDto? BotAdministratorRights { get; set; }

	/// <summary>
	/// Optional. Pass True to request a chat with the bot as a member. Otherwise, no additional restrictions are applied.
	/// </summary>
	[JsonPropertyName("bot_is_member")]
	public bool? BotIsMember { get; set; }
}