using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents a phone contact.
/// </summary>
public abstract class ContactDto
{
	/// <summary>
	/// Contact's phone number
	/// </summary>
	[JsonPropertyName("phone_number")]
	public string PhoneNumber { get; set; } = null!;

	/// <summary>
	/// Contact's first name
	/// </summary>
	[JsonPropertyName("first_name")]
	public string FirstName { get; set; } = null!;

	/// <summary>
	/// Optional. Contact's last name
	/// </summary>
	[JsonPropertyName("last_name")]
	public string? LastName { get; set; }

	/// <summary>
	/// Optional. Contact's user identifier in Telegram. This number may have more than 32 significant bits and some programming languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits, so a 64-bit integer or double-precision float type are safe for storing this identifier.
	/// </summary>
	[JsonPropertyName("user_id")]
	public int? UserId { get; set; }

	/// <summary>
	/// Optional. Additional data about the contact in the form of a vCard
	/// </summary>
	[JsonPropertyName("vcard")]
	public string? Vcard { get; set; }
}