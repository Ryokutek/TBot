using System.Text.Json.Serialization;
using TBot.Dto.Types;

namespace TBot.Dto.TelegramPassport;

/// <summary>
/// Describes Telegram Passport data shared with the bot by the user.
/// </summary>
public abstract class PassportDataDto
{
	/// <summary>
	/// Array with information about documents and other Telegram Passport elements that was shared with the bot
	/// </summary>
	[JsonPropertyName("data")]
	public List<EncryptedPassportElementDto> Data { get; set; } = null!;

	/// <summary>
	/// Encrypted credentials required to decrypt the data
	/// </summary>
	[JsonPropertyName("credentials")]
	public EncryptedCredentialsDto Credentials { get; set; } = null!;
}