namespace TBot.Core.Telegram;

public class PassportElementErrorTranslationFile
{
	public string Source { get; set; }
	public string Type { get; set; }
	public string FileHash { get; set; }
	public string Message { get; set; }

	public PassportElementErrorTranslationFile(
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