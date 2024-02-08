using System.Text.Json.Serialization;

namespace TBot.Core.Telegram;

public class Update
{
    [JsonPropertyName("update_id")]
    public int UpdateId { get; set; }
    public Message? Message { get; set; }
    public Message? EditedMessage { get; set; }
    public Message? ChannelPost { get; set; }
    public Message? EditedChannelPost { get; set; }
    public InlineQuery? InlineQuery { get; set; }
    public ChosenInlineResult? ChosenInlineResult { get; set; }
    public CallbackQuery? CallbackQuery { get; set; }
    public ShippingQuery? ShippingQuery { get; set; }
    public PreCheckoutQuery? PreCheckoutQuery { get; set; }
    public Poll? Poll { get; set; }
    public PollAnswer? PollAnswer { get; set; }
    public ChatMemberUpdated? MyChatMember { get; set; }
    public ChatMemberUpdated? ChatMember { get; set; }
    public ChatJoinRequest? ChatJoinRequest { get; set; }

    public Update(
        int updateId,
        Message? message, 
        Message? editedMessage,
        Message? channelPost,
        Message? editedChannelPost, 
        InlineQuery? inlineQuery,
        ChosenInlineResult? chosenInlineResult,
        CallbackQuery? callbackQuery, 
        ShippingQuery? shippingQuery, 
        PreCheckoutQuery? preCheckoutQuery,
        Poll? poll, 
        PollAnswer? pollAnswer,
        ChatMemberUpdated? myChatMember,
        ChatMemberUpdated? chatMember, 
        ChatJoinRequest? chatJoinRequest)
    {
        UpdateId = updateId;
        Message = message;
        EditedMessage = editedMessage;
        ChannelPost = channelPost;
        EditedChannelPost = editedChannelPost;
        InlineQuery = inlineQuery;
        ChosenInlineResult = chosenInlineResult;
        CallbackQuery = callbackQuery;
        ShippingQuery = shippingQuery;
        PreCheckoutQuery = preCheckoutQuery;
        Poll = poll;
        PollAnswer = pollAnswer;
        MyChatMember = myChatMember;
        ChatMember = chatMember;
        ChatJoinRequest = chatJoinRequest;
    }

    public bool IsMessage()
    {
        return Message is not null;
    }
    
    public bool IsCallbackQuery()
    {
        return CallbackQuery is not null;
    }
}