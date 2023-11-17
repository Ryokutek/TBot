namespace TBot.Core.Telegram;

public class PassportElementErrorTranslationFiles
{
	public string Source { get; set; }
	public string Type { get; set; }
	public List<string> FileHashes { get; set; }
	public string Message { get; set; }

	public PassportElementErrorTranslationFiles(
		string source,
		string type,
		List<string> fileHashes,
		string message)
	{
		Source = source;
		Type = type;
		FileHashes = fileHashes;
		Message = message;
	}
}