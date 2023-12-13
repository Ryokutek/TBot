using TBot.Core.RequestOptions.ReplyMarkupParameters;
using TBot.Core.RequestOptions.Structure;
using TBot.Core.Telegram;

namespace TBot.Core.RequestOptions.Stickers;

public class SendStickersOptions : BaseOptions
{
    [QueryParameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = null!;
    
    [QueryParameter("message_thread_id")]
    public int MessageThreadId { get; set; }

    [QueryParameter("sticker", Required = true)]
    public string Sticker { get; set; } = null!; //TODO: InputFile
    
    [QueryParameter("emoji")]
    public string Emoji { get; set; } = null!;
    
    [QueryParameter("disable_notification")]
    public bool DisableNotification { get; set; }
    
    [QueryParameter("protect_content")]
    public bool ProtectContent { get; set; }
    
    [QueryParameter("reply_to_message_id")]
    public int ReplyToMessageId { get; set; }
    
    [QueryParameter("allow_sending_without_reply")]
    public bool AllowSendingWithoutReply { get; set; }
    
    [QueryParameter("reply_markup", IsJson = true)]
    public ReplyMarkup? ReplyMarkup { get; set; }
}