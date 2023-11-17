namespace TBot.Core.Telegram;

public class ChatMemberMember
{
	public string Status { get; set; }
	public User User { get; set; }

	public ChatMemberMember(string status, User user)
	{
		Status = status;
		User = user;
	}
}