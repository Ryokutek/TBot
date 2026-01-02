using TBot.Core.RequestOptions.Structure;
using TBot.Dto.Types;

namespace TBot.Core.RequestOptions;

public abstract class DeleteMessageOptions(ChatIdentifier chatId, int messageId) : BaseOptions
{
    [QueryParameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = chatId;

    [QueryParameter("message_id", Required = true, IsJson = true)]
    public int MessageId { get; set; } = messageId;
}