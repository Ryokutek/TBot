namespace TBot.Core.Telegram;

public class KeyboardButtonRequestChat
{
	public int RequestId { get; set; }
	public bool ChatIsChannel { get; set; }
	public bool? ChatIsForum { get; set; }
	public bool? ChatHasUsername { get; set; }
	public bool? ChatIsCreated { get; set; }
	public ChatAdministratorRights? UserAdministratorRights { get; set; }
	public ChatAdministratorRights? BotAdministratorRights { get; set; }
	public bool? BotIsMember { get; set; }

	public KeyboardButtonRequestChat(
		int requestId,
		bool chatIsChannel,
		bool? chatIsForum,
		bool? chatHasUsername,
		bool? chatIsCreated,
		ChatAdministratorRights? userAdministratorRights,
		ChatAdministratorRights? botAdministratorRights,
		bool? botIsMember)
	{
		RequestId = requestId;
		ChatIsChannel = chatIsChannel;
		ChatIsForum = chatIsForum;
		ChatHasUsername = chatHasUsername;
		ChatIsCreated = chatIsCreated;
		UserAdministratorRights = userAdministratorRights;
		BotAdministratorRights = botAdministratorRights;
		BotIsMember = botIsMember;
	}
}