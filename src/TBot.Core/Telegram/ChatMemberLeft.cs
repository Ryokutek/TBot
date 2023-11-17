namespace TBot.Core.Telegram;

public class ChatMemberLeft
{
	public string Status { get; set; }
	public User User { get; set; }

	public ChatMemberLeft(string status, User user)
	{
		Status = status;
		User = user;
	}
}