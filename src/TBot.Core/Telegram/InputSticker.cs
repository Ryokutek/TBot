namespace TBot.Core.Telegram;

public class InputSticker
{
	public string Sticker { get; set; }
	public List<string> EmojiList { get; set; }
	public MaskPosition? MaskPosition { get; set; }
	public List<string> Keywords { get; set; }

	public InputSticker(
		string sticker,
		List<string> emojiList,
		MaskPosition? maskPosition,
		List<string> keywords)
	{
		Sticker = sticker;
		EmojiList = emojiList;
		MaskPosition = maskPosition;
		Keywords = keywords;
	}
}