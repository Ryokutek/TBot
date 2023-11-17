using TBot.Core.Parameters.ReplyMarkupParameters;
using TBot.Core.Parameters.Structure;
using TBot.Core.Telegram;

namespace TBot.Core.Parameters.Stickers;

public class SendStickersParameters : BaseParameters
{
    [Parameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = null!;
    
    [Parameter("message_thread_id")]
    public int MessageThreadId { get; set; }

    [Parameter("sticker", Required = true)]
    public string Sticker { get; set; } = null!; //TODO: InputFile
    
    [Parameter("emoji")]
    public string Emoji { get; set; } = null!;
    
    [Parameter("disable_notification")]
    public bool DisableNotification { get; set; }
    
    [Parameter("protect_content")]
    public bool ProtectContent { get; set; }
    
    [Parameter("reply_to_message_id")]
    public int ReplyToMessageId { get; set; }
    
    [Parameter("allow_sending_without_reply")]
    public bool AllowSendingWithoutReply { get; set; }
    
    [Parameter("reply_markup", IsJson = true)]
    public ReplyMarkup? ReplyMarkup { get; set; }
}