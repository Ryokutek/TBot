using System.Text.Json.Serialization;
using TBot.Dto.Types;

namespace TBot.Dto.Games;

/// <summary>
/// This object represents a game. Use BotFather to create and edit games, their short names will act as unique identifiers.
/// </summary>
public class GameDto
{
	/// <summary>
	/// Title of the game
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	/// <summary>
	/// Description of the game
	/// </summary>
	[JsonPropertyName("description")]
	public string Description { get; set; } = null!;

	/// <summary>
	/// Photo that will be displayed in the game message in chats.
	/// </summary>
	[JsonPropertyName("photo")]
	public List<PhotoSizeDto> Photo { get; set; } = null!;

	/// <summary>
	/// Optional. Brief description of the game or high scores included in the game message. Can be automatically edited to include current high scores for the game when the bot calls setGameScore, or manually edited using editMessageText. 0-4096 characters.
	/// </summary>
	[JsonPropertyName("text")]
	public string? Text { get; set; }

	/// <summary>
	/// Optional. Special entities that appear in text, such as usernames, URLs, bot commands, etc.
	/// </summary>
	[JsonPropertyName("text_entities")]
	public List<MessageEntityDto>? TextEntities { get; set; }

	/// <summary>
	/// Optional. Animation that will be displayed in the game message in chats. Upload via BotFather
	/// </summary>
	[JsonPropertyName("animation")]
	public AnimationDto? Animation { get; set; }
}