namespace TBot.Core.Telegram;

public class EncryptedPassportElement
{
	public string Type { get; set; }
	public string? Data { get; set; }
	public string? PhoneNumber { get; set; }
	public string? Email { get; set; }
	public List<PassportFile> Files { get; set; }
	public PassportFile? FrontSide { get; set; }
	public PassportFile? ReverseSide { get; set; }
	public PassportFile? Selfie { get; set; }
	public List<PassportFile> Translation { get; set; }
	public string Hash { get; set; }

	public EncryptedPassportElement(
		string type,
		string? data,
		string? phoneNumber,
		string? email,
		List<PassportFile> files,
		PassportFile? frontSide,
		PassportFile? reverseSide,
		PassportFile? selfie,
		List<PassportFile> translation,
		string hash)
	{
		Type = type;
		Data = data;
		PhoneNumber = phoneNumber;
		Email = email;
		Files = files;
		FrontSide = frontSide;
		ReverseSide = reverseSide;
		Selfie = selfie;
		Translation = translation;
		Hash = hash;
	}
}