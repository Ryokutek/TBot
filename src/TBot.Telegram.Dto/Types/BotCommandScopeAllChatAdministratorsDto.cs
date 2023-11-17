using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// Represents the scope of bot commands, covering all group and supergroup chat administrators.
/// </summary>
public class BotCommandScopeAllChatAdministratorsDto
{
	/// <summary>
	/// Scope type, must be all_chat_administrators
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;
}