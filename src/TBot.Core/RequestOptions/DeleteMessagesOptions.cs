using TBot.Core.RequestOptions.Structure;
using TBot.Core.Telegram;

namespace TBot.Core.RequestOptions;

public class DeleteMessagesOptions : BaseOptions
{
    public DeleteMessagesOptions(ChatIdentifier chatId, List<int> messageId)
    {
        ChatId = chatId;
        MessageIds = messageId;
    }
    
    [QueryParameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; }

    [QueryParameter("message_ids", Required = true, IsJson = true)]
    public List<int> MessageIds { get; set; }
}