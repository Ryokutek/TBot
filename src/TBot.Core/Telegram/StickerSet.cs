namespace TBot.Core.Telegram;

public class StickerSet
{
	public string Name { get; set; }
	public string Title { get; set; }
	public string StickerType { get; set; }
	public bool IsAnimated { get; set; }
	public bool IsVideo { get; set; }
	public List<Sticker> Stickers { get; set; }
	public PhotoSize? Thumbnail { get; set; }

	public StickerSet(
		string name,
		string title,
		string stickerType,
		bool isAnimated,
		bool isVideo,
		List<Sticker> stickers,
		PhotoSize? thumbnail)
	{
		Name = name;
		Title = title;
		StickerType = stickerType;
		IsAnimated = isAnimated;
		IsVideo = isVideo;
		Stickers = stickers;
		Thumbnail = thumbnail;
	}
}