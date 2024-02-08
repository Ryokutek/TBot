using TBot.Core.RequestOptions.Reply.MarkumParameters;
using TBot.Core.RequestOptions.Structure;
using TBot.Core.Telegram;
using InputFile = TBot.Core.RequestOptions.Inputs.InputFile;

namespace TBot.Core.RequestOptions;

public class SendVideoOptions : BaseOptions
{
    public SendVideoOptions(ChatIdentifier chatId, InputFile video)
    {
        ChatId = chatId;
        Video = video;
    }
    
    [QueryParameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; }
    
    [QueryParameter("message_thread_id")]
    public int MessageThreadId { get; set; }
    
    [ContentParameter("video", Required = true)]
    public InputFile Video { get; set; } = null!;
    
    [QueryParameter("duration")]
    public int? Duration { get; set; }
    
    [QueryParameter("width")]
    public int? Width { get; set; }
    
    [ContentParameter("thumbnail")]
    public InputFile? Thumbnail { get; set; }
    
    [QueryParameter("caption")]
    public string? Caption { get; set; }
    
    [QueryParameter("parse_mode")]
    public ParseMode? ParseMode { get; set; }
    
    [QueryParameter("caption_entities")]
    public List<MessageEntity>? CaptionEntities { get; set; }
    
    [QueryParameter("has_spoiler")]
    public bool? HasSpoiler { get; set; }
    
    [QueryParameter("supports_streaming")]
    public bool? SupportsStreaming { get; set; }
    
    [QueryParameter("disable_notification")]
    public bool? DisableNotification { get; set; }
    
    [QueryParameter("protect_content")]
    public bool? ProtectContent { get; set; }
    
    [QueryParameter("reply_to_message_id")]
    public int? ReplyToMessageId { get; set; }
    
    [QueryParameter("allow_sending_without_reply")]
    public bool? AllowSendingWithoutReply { get; set; }
    
    [QueryParameter("reply_markup")]
    public ReplyMarkup? ReplyMarkup { get; set; }
}