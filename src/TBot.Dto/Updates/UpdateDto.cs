using System.Text.Json.Serialization;
using TBot.Dto.Types;
using ChosenInlineResultDto = TBot.Dto.InlineModes.ChosenInlineResultDto;
using InlineQueryDto = TBot.Dto.InlineModes.InlineQueryDto;
using PreCheckoutQueryDto = TBot.Dto.Payments.PreCheckoutQueryDto;
using ShippingQueryDto = TBot.Dto.Payments.ShippingQueryDto;

namespace TBot.Dto.Updates;

/// <summary>
/// This object represents an incoming update.
/// At most one of the optional parameters can be present in any given update.
/// </summary>
public class UpdateDto
{
    /// <summary>
    /// The update's unique identifier. Update identifiers start from a certain positive number and increase sequentially.
    /// </summary>
    [JsonPropertyName("update_id")]
    public int UpdateId { get; set; }

    /// <summary>
    /// New incoming message of any kind - text, photo, sticker, etc.
    /// </summary>
    [JsonPropertyName("message")]
    public MessageDto? Message { get; set; }

    /// <summary>
    /// New version of a message that is known to the bot and was edited.
    /// </summary>
    [JsonPropertyName("edited_message")]
    public MessageDto? EditedMessage { get; set; }

    /// <summary>
    /// New incoming channel post of any kind - text, photo, sticker, etc.
    /// </summary>
    [JsonPropertyName("channel_post")]
    public MessageDto? ChannelPost { get; set; }

    /// <summary>
    /// New version of a channel post that is known to the bot and was edited.
    /// </summary>
    [JsonPropertyName("edited_channel_post")]
    public MessageDto? EditedChannelPost { get; set; }

    /// <summary>
    /// New incoming inline query.
    /// </summary>
    [JsonPropertyName("inline_query")]
    public InlineQueryDto? InlineQuery { get; set; }

    /// <summary>
    /// The result of an inline query that was chosen by a user and sent to their chat partner.
    /// </summary>
    [JsonPropertyName("chosen_inline_result")]
    public ChosenInlineResultDto? ChosenInlineResult { get; set; }

    /// <summary>
    /// New incoming callback query.
    /// </summary>
    [JsonPropertyName("callback_query")]
    public CallbackQueryDto? CallbackQuery { get; set; }

    /// <summary>
    /// New incoming shipping query. Only for invoices with flexible price.
    /// </summary>
    [JsonPropertyName("shipping_query")]
    public ShippingQueryDto? ShippingQuery { get; set; }

    /// <summary>
    /// New incoming pre-checkout query. Contains full information about checkout.
    /// </summary>
    [JsonPropertyName("pre_checkout_query")]
    public PreCheckoutQueryDto? PreCheckoutQuery { get; set; }

    /// <summary>
    /// New poll state. Bots receive only updates about stopped polls and polls, which are sent by the bot.
    /// </summary>
    [JsonPropertyName("poll")]
    public PollDto? Poll { get; set; }

    /// <summary>
    /// A user changed their answer in a non-anonymous poll. Bots receive new votes only in polls that were sent by the bot itself.
    /// </summary>
    [JsonPropertyName("poll_answer")]
    public PollAnswerDto? PollAnswer { get; set; }

    /// <summary>
    /// The bot's chat member status was updated in a chat. For private chats, this update is received only when the bot is blocked or unblocked by the user.
    /// </summary>
    [JsonPropertyName("my_chat_member")]
    public ChatMemberUpdatedDto? MyChatMember { get; set; }

    /// <summary>
    /// A chat member's status was updated in a chat. The bot must be an administrator in the chat and must explicitly specify “chat_member” in the list of allowed_updates to receive these updates.
    /// </summary>
    [JsonPropertyName("chat_member")]
    public ChatMemberUpdatedDto? ChatMember { get; set; }

    /// <summary>
    /// A request to join the chat has been sent. The bot must have the can_invite_users administrator right in the chat to receive these updates.
    /// </summary>
    [JsonPropertyName("chat_join_request")]
    public ChatJoinRequestDto? ChatJoinRequest { get; set; }
}