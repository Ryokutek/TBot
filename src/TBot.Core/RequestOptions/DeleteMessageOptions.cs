using TBot.Core.RequestOptions.Structure;
using TBot.Core.Telegram;

namespace TBot.Core.RequestOptions;

public class DeleteMessageOptions : BaseOptions
{
    [QueryParameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = null!;
    
    [QueryParameter("message_id", Required = true)]
    public int MessageId { get; set; }
}