namespace TBot.Core.Telegram;

public class ChatMemberUpdated
{
	public Chat Chat { get; set; }
	public User From { get; set; }
	public int Date { get; set; }
	public ChatMember OldChatMember { get; set; }
	public ChatMember NewChatMember { get; set; }
	public ChatInviteLink? InviteLink { get; set; }
	public bool? ViaChatFolderInviteLink { get; set; }

	public ChatMemberUpdated(
		Chat chat,
		User from,
		int date,
		ChatMember oldChatMember,
		ChatMember newChatMember,
		ChatInviteLink? inviteLink,
		bool? viaChatFolderInviteLink)
	{
		Chat = chat;
		From = from;
		Date = date;
		OldChatMember = oldChatMember;
		NewChatMember = newChatMember;
		InviteLink = inviteLink;
		ViaChatFolderInviteLink = viaChatFolderInviteLink;
	}
}