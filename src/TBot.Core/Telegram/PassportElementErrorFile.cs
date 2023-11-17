namespace TBot.Core.Telegram;

public class PassportElementErrorFile
{
	public string Source { get; set; }
	public string Type { get; set; }
	public string FileHash { get; set; }
	public string Message { get; set; }

	public PassportElementErrorFile(
		string source,
		string type,
		string fileHash,
		string message)
	{
		Source = source;
		Type = type;
		FileHash = fileHash;
		Message = message;
	}
}