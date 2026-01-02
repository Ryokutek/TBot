using TBot.Core.RequestOptions.Reply.MarkumParameters;
using TBot.Core.RequestOptions.Structure;
using TBot.Dto.Types;

namespace TBot.Core.RequestOptions.Stickers;

public class SendStickersOptions(ChatIdentifier chatId, InputFile sticker) : BaseOptions
{
    [QueryParameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = chatId;

    [QueryParameter("message_thread_id")]
    public int MessageThreadId { get; set; }

    [QueryParameter("sticker", Required = true)]
    public InputFile Sticker { get; set; } = sticker;

    [QueryParameter("emoji")]
    public string Emoji { get; set; } = null!;
    
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