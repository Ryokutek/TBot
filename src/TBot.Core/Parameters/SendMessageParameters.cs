using TBot.Core.Parameters.ReplyMarkupParameters;
using TBot.Core.Parameters.Structure;
using TBot.Core.Telegram;

namespace TBot.Core.Parameters;

public class SendMessageParameters : BaseParameters
{
    [Parameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = null!;
    
    [Parameter("message_thread_id")]
    public int MessageThreadId { get; set; }

    [Parameter("text", Required = true)]
    public string Text { get; set; } = null!;
    
    [Parameter("parse_mode")]
    public ParseMode? ParseMode { get; set; }
        
    [Parameter("entities")]
    public List<MessageEntity>? Entities { get; set; }
    
    [Parameter("disable_web_page_preview")]
    public bool DisableWebPagePreview { get; set; }
    
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

public enum ParseMode
{
    MarkdownV2,
    Markdown,
    HTML
}