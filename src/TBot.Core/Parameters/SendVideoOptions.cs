using TBot.Core.Parameters.Structure;
using TBot.Core.Telegram;
using InputFile = TBot.Core.Parameters.InputFileParameters.InputFile;

namespace TBot.Core.Parameters;

public class SendVideoOptions : BaseOptions
{
    [QueryParameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = null!;
    
    [QueryParameter("message_thread_id")]
    public int MessageThreadId { get; set; }
    
    [ContentParameter("video", Required = true)]
    public InputFile Video { get; set; } = null!;
}