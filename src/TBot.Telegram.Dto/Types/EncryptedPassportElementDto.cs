using System.Collections.Generic;
using System.Text.Json.Serialization;
using TBot.Telegram.Dto.TelegramPassport;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// Describes documents or other Telegram Passport elements shared with the bot by the user.
/// </summary>
public class EncryptedPassportElementDto
{
	/// <summary>
	/// Element type. One of “personal_details”, “passport”, “driver_license”, “identity_card”, “internal_passport”, “address”, “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration”, “temporary_registration”, “phone_number”, “email”.
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Optional. Base64-encoded encrypted Telegram Passport element data provided by the user, available for “personal_details”, “passport”, “driver_license”, “identity_card”, “internal_passport” and “address” types. Can be decrypted and verified using the accompanying EncryptedCredentials.
	/// </summary>
	[JsonPropertyName("data")]
	public string? Data { get; set; }

	/// <summary>
	/// Optional. User's verified phone number, available only for “phone_number” type
	/// </summary>
	[JsonPropertyName("phone_number")]
	public string? PhoneNumber { get; set; }

	/// <summary>
	/// Optional. User's verified email address, available only for “email” type
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Optional. Array of encrypted files with documents provided by the user, available for “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration” and “temporary_registration” types. Files can be decrypted and verified using the accompanying EncryptedCredentials.
	/// </summary>
	[JsonPropertyName("files")]
	public List<PassportFileDto>? Files { get; set; }

	/// <summary>
	/// Optional. Encrypted file with the front side of the document, provided by the user. Available for “passport”, “driver_license”, “identity_card” and “internal_passport”. The file can be decrypted and verified using the accompanying EncryptedCredentials.
	/// </summary>
	[JsonPropertyName("front_side")]
	public PassportFileDto? FrontSide { get; set; }

	/// <summary>
	/// Optional. Encrypted file with the reverse side of the document, provided by the user. Available for “driver_license” and “identity_card”. The file can be decrypted and verified using the accompanying EncryptedCredentials.
	/// </summary>
	[JsonPropertyName("reverse_side")]
	public PassportFileDto? ReverseSide { get; set; }

	/// <summary>
	/// Optional. Encrypted file with the selfie of the user holding a document, provided by the user; available for “passport”, “driver_license”, “identity_card” and “internal_passport”. The file can be decrypted and verified using the accompanying EncryptedCredentials.
	/// </summary>
	[JsonPropertyName("selfie")]
	public PassportFileDto? Selfie { get; set; }

	/// <summary>
	/// Optional. Array of encrypted files with translated versions of documents provided by the user. Available if requested for “passport”, “driver_license”, “identity_card”, “internal_passport”, “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration” and “temporary_registration” types. Files can be decrypted and verified using the accompanying EncryptedCredentials.
	/// </summary>
	[JsonPropertyName("translation")]
	public List<PassportFileDto>? Translation { get; set; }

	/// <summary>
	/// Base64-encoded element hash for using in PassportElementErrorUnspecified
	/// </summary>
	[JsonPropertyName("hash")]
	public string Hash { get; set; } = null!;
}