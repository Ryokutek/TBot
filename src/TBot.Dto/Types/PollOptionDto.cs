using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object contains information about one answer option in a poll.
/// </summary>
public class PollOptionDto
{
	/// <summary>
	/// Option text, 1-100 characters
	/// </summary>
	[JsonPropertyName("text")]
	public string Text { get; set; } = null!;

	/// <summary>
	/// Number of users that voted for this option
	/// </summary>
	[JsonPropertyName("voter_count")]
	public int VoterCount { get; set; }
}