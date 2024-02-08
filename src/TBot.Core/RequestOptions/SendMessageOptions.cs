using TBot.Core.RequestOptions.Reply.MarkumParameters;
using TBot.Core.RequestOptions.Structure;
using TBot.Core.Telegram;

namespace TBot.Core.RequestOptions;

public class SendMessageOptions : BaseOptions
{
    public SendMessageOptions(ChatIdentifier chatId, string text)
    {
        ChatId = chatId;
        Text = text;
    }
    
    [QueryParameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; }
    
    [QueryParameter("message_thread_id")]
    public int MessageThreadId { get; set; }

    [QueryParameter("text", Required = true)]
    public string Text { get; set; }
    
    [QueryParameter("parse_mode")]
    public ParseMode? ParseMode { get; set; }
        
    [QueryParameter("entities")]
    public List<MessageEntity>? Entities { get; set; }
    
    [QueryParameter("disable_web_page_preview")]
    public bool DisableWebPagePreview { get; set; }
    
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

public enum ParseMode
{
    MarkdownV2,
    Markdown,
    Html
}