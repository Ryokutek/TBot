namespace TBot.Core.Telegram;

public class ChatMemberOwner
{
	public string Status { get; set; }
	public User User { get; set; }
	public bool IsAnonymous { get; set; }
	public string? CustomTitle { get; set; }

	public ChatMemberOwner(
		string status,
		User user,
		bool isAnonymous,
		string? customTitle)
	{
		Status = status;
		User = user;
		IsAnonymous = isAnonymous;
		CustomTitle = customTitle;
	}
}