namespace TBot.Core.Telegram;

public class GameHighScore
{
	public int Position { get; set; }
	public User User { get; set; }
	public int Score { get; set; }

	public GameHighScore(int position, User user, int score)
	{
		Position = position;
		User = user;
		Score = score;
	}
}