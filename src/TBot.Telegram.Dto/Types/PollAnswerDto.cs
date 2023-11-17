using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represents an answer of a user in a non-anonymous poll.
/// </summary>
public class PollAnswerDto
{
	/// <summary>
	/// Unique poll identifier
	/// </summary>
	[JsonPropertyName("poll_id")]
	public string PollId { get; set; } = null!;

	/// <summary>
	/// The user, who changed the answer to the poll
	/// </summary>
	[JsonPropertyName("user")]
	public UserDto User { get; set; } = null!;

	/// <summary>
	/// 0-based identifiers of answer options, chosen by the user. May be empty if the user retracted their vote.
	/// </summary>
	[JsonPropertyName("option_ids")]
	public List<int> OptionIds { get; set; } = null!;
}