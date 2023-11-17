namespace TBot.Core.Telegram;

public class PollOption
{
	public string Text { get; set; }
	public int VoterCount { get; set; }

	public PollOption(string text, int voterCount)
	{
		Text = text;
		VoterCount = voterCount;
	}
}