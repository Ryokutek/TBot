using System.Text.Json.Serialization;
using TBot.Dto.Types;

namespace TBot.Dto.Games;

/// <summary>
/// This object represents one row of the high scores table for a game.
/// </summary>
public abstract class GameHighScoreDto
{
	/// <summary>
	/// Position in high score table for the game
	/// </summary>
	[JsonPropertyName("position")]
	public int Position { get; set; }

	/// <summary>
	/// User
	/// </summary>
	[JsonPropertyName("user")]
	public UserDto User { get; set; } = null!;

	/// <summary>
	/// Score
	/// </summary>
	[JsonPropertyName("score")]
	public int Score { get; set; }
}