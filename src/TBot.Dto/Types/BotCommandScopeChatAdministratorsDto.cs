using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Represents the scope of bot commands, covering all administrators of a specific group or supergroup chat.
/// </summary>
public class BotCommandScopeChatAdministratorsDto
{
	/// <summary>
	/// Scope type, must be chat_administrators
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername)
	/// </summary>
	[JsonPropertyName("chat_id")]
	public ChatIdentifier ChatId { get; set; } = null!;
}