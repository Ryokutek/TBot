namespace TBot.Core.Telegram;

public class ChatMemberBanned
{
	public string Status { get; set; }
	public User User { get; set; }
	public int UntilDate { get; set; }

	public ChatMemberBanned(string status, User user, int untilDate)
	{
		Status = status;
		User = user;
		UntilDate = untilDate;
	}
}