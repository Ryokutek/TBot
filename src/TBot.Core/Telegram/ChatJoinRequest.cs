namespace TBot.Core.Telegram;

public class ChatJoinRequest
{
	public Chat Chat { get; set; }
	public User From { get; set; }
	public int UserChatId { get; set; }
	public int Date { get; set; }
	public string? Bio { get; set; }
	public ChatInviteLink? InviteLink { get; set; }

	public ChatJoinRequest(
		Chat chat,
		User from,
		int userChatId,
		int date,
		string? bio,
		ChatInviteLink? inviteLink)
	{
		Chat = chat;
		From = from;
		UserChatId = userChatId;
		Date = date;
		Bio = bio;
		InviteLink = inviteLink;
	}
}