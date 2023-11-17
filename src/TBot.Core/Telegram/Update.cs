namespace TBot.Core.Telegram;

public class Update
{
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
}