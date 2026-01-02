using TBot.Core.RequestOptions.Reply.MarkumParameters;
using TBot.Core.RequestOptions.Structure;
using TBot.Dto.Types;

namespace TBot.Core.RequestOptions;

public class SendPhotoOption(ChatIdentifier chatId, InputFile photo) : BaseOptions
{
    [QueryParameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = chatId;

    [QueryParameter("message_thread_id")]
    public int MessageThreadId { get; set; }
    
    [ContentParameter("photo", Required = true)]
    public InputFile Photo { get; set; } = photo;

    [QueryParameter("caption")]
    public string? Caption { get; set; }
    
    [QueryParameter("parse_mode")]
    public ParseMode? ParseMode { get; set; }
    
    [QueryParameter("caption_entities")]
    public List<MessageEntityDto>? CaptionEntities { get; set; }
    
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