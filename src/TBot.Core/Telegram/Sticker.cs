namespace TBot.Core.Telegram;

public class Sticker
{
	public string FileId { get; set; }
	public string FileUniqueId { get; set; }
	public string Type { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }
	public bool IsAnimated { get; set; }
	public bool IsVideo { get; set; }
	public PhotoSize? Thumbnail { get; set; }
	public string? Emoji { get; set; }
	public string? SetName { get; set; }
	public TelegramFile? PremiumAnimation { get; set; }
	public MaskPosition? MaskPosition { get; set; }
	public string? CustomEmojiId { get; set; }
	public bool? NeedsRepainting { get; set; }
	public int? FileSize { get; set; }

	public Sticker(
		string fileId,
		string fileUniqueId,
		string type,
		int width,
		int height,
		bool isAnimated,
		bool isVideo,
		PhotoSize? thumbnail,
		string? emoji,
		string? setName,
		TelegramFile? premiumAnimation,
		MaskPosition? maskPosition,
		string? customEmojiId,
		bool? needsRepainting,
		int? fileSize)
	{
		FileId = fileId;
		FileUniqueId = fileUniqueId;
		Type = type;
		Width = width;
		Height = height;
		IsAnimated = isAnimated;
		IsVideo = isVideo;
		Thumbnail = thumbnail;
		Emoji = emoji;
		SetName = setName;
		PremiumAnimation = premiumAnimation;
		MaskPosition = maskPosition;
		CustomEmojiId = customEmojiId;
		NeedsRepainting = needsRepainting;
		FileSize = fileSize;
	}
}