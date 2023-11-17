namespace TBot.Core.Telegram;

public class ReplyKeyboardRemove
{
	public bool RemoveKeyboard { get; set; }
	public bool? Selective { get; set; }

	public ReplyKeyboardRemove(bool removeKeyboard, bool? selective)
	{
		RemoveKeyboard = removeKeyboard;
		Selective = selective;
	}
}