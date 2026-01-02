using TBot.Core.RequestOptions.Reply;
using TBot.Core.RequestOptions.Reply.MarkumParameters;
using TBot.Core.RequestOptions.Structure;
using TBot.Dto.Types;

namespace TBot.Core.RequestOptions;

public class SendAudioOptions(ChatIdentifier chatId, InputFile audio) : BaseOptions
{
    [QueryParameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = chatId;

    [QueryParameter("message_thread_id")]
    public int MessageThreadId { get; set; }
    
    [ContentParameter("audio", Required = true)]
    public InputFile Audio { get; set; } = audio;

    [QueryParameter("caption")]
    public string? Caption { get; set; }
    
    [QueryParameter("parse_mode")]
    public ParseMode? ParseMode { get; set; }
    
    [QueryParameter("caption_entities")]
    public List<MessageEntityDto>? CaptionEntities { get; set; }
    
    [QueryParameter("duration")]
    public int? Duration { get; set; }
    
    [QueryParameter("performer")]
    public string? Performer { get; set; }
    
    [QueryParameter("title")]
    public string? Title { get; set; }
    
    [ContentParameter("thumbnail")]
    public InputFile? Thumbnail { get; set; }
    
    [QueryParameter("disable_notification")]
    public bool? DisableNotification { get; set; }
    
    [QueryParameter("protect_content")]
    public bool? ProtectContent { get; set; }
    
    [QueryParameter("reply_parameters")]
    public ReplyParameters? ReplyParameters { get; set; }
    
    [QueryParameter("reply_markup")]
    public ReplyMarkup? ReplyMarkup { get; set; }
    
}