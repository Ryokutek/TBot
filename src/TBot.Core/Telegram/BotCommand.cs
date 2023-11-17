namespace TBot.Core.Telegram;

public class BotCommand
{
	public string Command { get; set; }
	public string Description { get; set; }

	public BotCommand(string command, string description)
	{
		Command = command;
		Description = description;
	}
}