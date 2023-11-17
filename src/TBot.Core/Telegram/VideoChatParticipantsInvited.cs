namespace TBot.Core.Telegram;

public class VideoChatParticipantsInvited
{
	public List<User> Users { get; set; }

	public VideoChatParticipantsInvited(List<User> users)
	{
		Users = users;
	}
}