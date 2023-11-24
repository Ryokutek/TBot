using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Represents the scope of bot commands, covering all group and supergroup chats.
/// </summary>
public class BotCommandScopeAllGroupChatsDto
{
	/// <summary>
	/// Scope type, must be all_group_chats
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;
}