namespace TBot.Core.Telegram;

public class ForceReply
{
	public bool IsForceReply { get; set; }
	public string? InputFieldPlaceholder { get; set; }
	public bool? Selective { get; set; }

	public ForceReply(bool isForceReply, string? inputFieldPlaceholder, bool? selective)
	{
		IsForceReply = isForceReply;
		InputFieldPlaceholder = inputFieldPlaceholder;
		Selective = selective;
	}
}