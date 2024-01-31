using TBot.Core.RequestOptions.Structure;
using TBot.Core.Telegram;

namespace TBot.Core.RequestOptions.Reply;

public class ReplyParameters
{
    public ReplyParameters(int messageId)
    {
        MessageId = messageId;
    }
    
    [QueryParameter("message_id", Required = true)]
    public int MessageId { get; set; }
    
    [QueryParameter("chat_id")]
    public ChatIdentifier? ChatId { get; set; }
    
    [QueryParameter("allow_sending_without_reply")]
    public bool? AllowSendingWithoutReply { get; set; }

    [QueryParameter("quote")]
    public string? Quote { get; set; }
    
    [QueryParameter("quote_parse_mode")]
    public ParseMode? QuoteParseMode { get; set; }
    
    [QueryParameter("quote_position")]
    public List<MessageEntity>? MessageEntities { get; set; }
    
    [QueryParameter("quote_position", Required = true)]
    public int? QuotePosition { get; set; }
}