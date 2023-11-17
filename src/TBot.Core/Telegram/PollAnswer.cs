namespace TBot.Core.Telegram;

public class PollAnswer
{
	public string PollId { get; set; }
	public Chat? VoterChat { get; set; }
	public User? User { get; set; }
	public List<int> OptionIds { get; set; }

	public PollAnswer(
		string pollId,
		Chat? voterChat,
		User? user,
		List<int> optionIds)
	{
		PollId = pollId;
		VoterChat = voterChat;
		User = user;
		OptionIds = optionIds;
	}
}