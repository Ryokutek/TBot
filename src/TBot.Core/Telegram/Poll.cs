namespace TBot.Core.Telegram;

public class Poll
{
	public string Id { get; set; }
	public string Question { get; set; }
	public List<PollOption> Options { get; set; }
	public int TotalVoterCount { get; set; }
	public bool IsClosed { get; set; }
	public bool IsAnonymous { get; set; }
	public string Type { get; set; }
	public bool AllowsMultipleAnswers { get; set; }
	public int? CorrectOptionId { get; set; }
	public string? Explanation { get; set; }
	public List<MessageEntity> ExplanationEntities { get; set; }
	public int? OpenPeriod { get; set; }
	public int? CloseDate { get; set; }

	public Poll(
		string id,
		string question,
		List<PollOption> options,
		int totalVoterCount,
		bool isClosed,
		bool isAnonymous,
		string type,
		bool allowsMultipleAnswers,
		int? correctOptionId,
		string? explanation,
		List<MessageEntity> explanationEntities,
		int? openPeriod,
		int? closeDate)
	{
		Id = id;
		Question = question;
		Options = options;
		TotalVoterCount = totalVoterCount;
		IsClosed = isClosed;
		IsAnonymous = isAnonymous;
		Type = type;
		AllowsMultipleAnswers = allowsMultipleAnswers;
		CorrectOptionId = correctOptionId;
		Explanation = explanation;
		ExplanationEntities = explanationEntities;
		OpenPeriod = openPeriod;
		CloseDate = closeDate;
	}
}