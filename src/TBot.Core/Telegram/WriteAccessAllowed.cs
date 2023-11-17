namespace TBot.Core.Telegram;

public class WriteAccessAllowed
{
	public bool? FromRequest { get; set; }
	public string? WebAppName { get; set; }
	public bool? FromAttachmentMenu { get; set; }

	public WriteAccessAllowed(bool? fromRequest, string? webAppName, bool? fromAttachmentMenu)
	{
		FromRequest = fromRequest;
		WebAppName = webAppName;
		FromAttachmentMenu = fromAttachmentMenu;
	}
}