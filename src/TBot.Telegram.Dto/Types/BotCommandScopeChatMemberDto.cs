using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// Represents the scope of bot commands, covering a specific member of a group or supergroup chat.
/// </summary>
public class BotCommandScopeChatMemberDto
{
	/// <summary>
	/// Scope type, must be chat_member
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername)
	/// </summary>
	[JsonPropertyName("chat_id")]
	public ChatIdentifier ChatId { get; set; } = null!;

	/// <summary>
	/// Unique identifier of the target user
	/// </summary>
	[JsonPropertyName("user_id")]
	public int UserId { get; set; }
}