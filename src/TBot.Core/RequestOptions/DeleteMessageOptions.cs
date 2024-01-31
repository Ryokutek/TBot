using TBot.Core.RequestOptions.Structure;
using TBot.Core.Telegram;

namespace TBot.Core.RequestOptions;

public class DeleteMessageOptions : BaseOptions
{
    public DeleteMessageOptions(ChatIdentifier chatId, int messageId)
    {
        ChatId = chatId;
        MessageId = messageId;
    }
    
    [QueryParameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; }

    [QueryParameter("message_id", Required = true, IsJson = true)]
    public int MessageId { get; set; }
}