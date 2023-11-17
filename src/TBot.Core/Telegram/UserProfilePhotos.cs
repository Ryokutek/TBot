namespace TBot.Core.Telegram;

public class UserProfilePhotos
{
	public int TotalCount { get; set; }
	public List<PhotoSize> Photos { get; set; }

	public UserProfilePhotos(int totalCount, List<PhotoSize> photos)
	{
		TotalCount = totalCount;
		Photos = photos;
	}
}