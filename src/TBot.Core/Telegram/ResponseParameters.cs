namespace TBot.Core.Telegram;

public class ResponseParameters
{
	public int? MigrateToChatId { get; set; }
	public int? RetryAfter { get; set; }

	public ResponseParameters(int? migrateToChatId, int? retryAfter)
	{
		MigrateToChatId = migrateToChatId;
		RetryAfter = retryAfter;
	}
}