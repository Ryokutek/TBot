namespace TBot.Core.Telegram;

public class SwitchInlineQueryChosenChat
{
	public string? Query { get; set; }
	public bool? AllowUserChats { get; set; }
	public bool? AllowBotChats { get; set; }
	public bool? AllowGroupChats { get; set; }
	public bool? AllowChannelChats { get; set; }

	public SwitchInlineQueryChosenChat(
		string? query,
		bool? allowUserChats,
		bool? allowBotChats,
		bool? allowGroupChats,
		bool? allowChannelChats)
	{
		Query = query;
		AllowUserChats = allowUserChats;
		AllowBotChats = allowBotChats;
		AllowGroupChats = allowGroupChats;
		AllowChannelChats = allowChannelChats;
	}
}