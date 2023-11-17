namespace TBot.Core.Telegram;

public class PassportElementErrorDataField
{
	public string Source { get; set; }
	public string Type { get; set; }
	public string FieldName { get; set; }
	public string DataHash { get; set; }
	public string Message { get; set; }

	public PassportElementErrorDataField(
		string source,
		string type,
		string fieldName,
		string dataHash,
		string message)
	{
		Source = source;
		Type = type;
		FieldName = fieldName;
		DataHash = dataHash;
		Message = message;
	}
}