using TBot.Core.RequestOptions.Structure;
using TBot.Dto.Types;

namespace TBot.Core.RequestOptions;

public class DeleteMessagesOptions(ChatIdentifier chatId, List<int> messageId) : BaseOptions
{
    [QueryParameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = chatId;

    [QueryParameter("message_ids", Required = true, IsJson = true)]
    public List<int> MessageIds { get; set; } = messageId;
}