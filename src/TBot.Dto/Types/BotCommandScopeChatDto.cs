using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Represents the scope of bot commands, covering a specific chat.
/// </summary>
public class BotCommandScopeChatDto
{
	/// <summary>
	/// Scope type, must be chat
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername)
	/// </summary>
	[JsonPropertyName("chat_id")]
	public ChatIdentifier ChatId { get; set; } = null!;
}