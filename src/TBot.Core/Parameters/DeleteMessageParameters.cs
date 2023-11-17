using TBot.Core.Parameters.Structure;
using TBot.Core.Telegram;

namespace TBot.Core.Parameters;

public class DeleteMessageParameters : BaseParameters
{
    [Parameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = null!;
    
    [Parameter("message_id", Required = true)]
    public int MessageId { get; set; }
}