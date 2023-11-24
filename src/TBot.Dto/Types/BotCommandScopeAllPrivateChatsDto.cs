using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Represents the scope of bot commands, covering all private chats.
/// </summary>
public class BotCommandScopeAllPrivateChatsDto
{
	/// <summary>
	/// Scope type, must be all_private_chats
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;
}