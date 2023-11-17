namespace TBot.Core.Telegram;

public class ReplyKeyboardMarkup
{
	public List<KeyboardButton> Keyboard { get; set; }
	public bool? IsPersistent { get; set; }
	public bool? ResizeKeyboard { get; set; }
	public bool? OneTimeKeyboard { get; set; }
	public string? InputFieldPlaceholder { get; set; }
	public bool? Selective { get; set; }

	public ReplyKeyboardMarkup(
		List<KeyboardButton> keyboard,
		bool? isPersistent,
		bool? resizeKeyboard,
		bool? oneTimeKeyboard,
		string? inputFieldPlaceholder,
		bool? selective)
	{
		Keyboard = keyboard;
		IsPersistent = isPersistent;
		ResizeKeyboard = resizeKeyboard;
		OneTimeKeyboard = oneTimeKeyboard;
		InputFieldPlaceholder = inputFieldPlaceholder;
		Selective = selective;
	}
}