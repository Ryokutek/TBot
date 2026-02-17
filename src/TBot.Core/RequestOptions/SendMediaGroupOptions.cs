using TBot.Core.RequestManagement.Models;
using TBot.Core.RequestOptions.Structure;
using TBot.Dto.Types;
using InputMedia = TBot.Core.RequestOptions.Inputs.Media.InputMedia;

namespace TBot.Core.RequestOptions;

public class SendMediaGroupOptions(ChatIdentifier chatId, List<InputMedia> mediaSet) : BaseOptions
{
    [QueryParameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = chatId;

    [QueryParameter("message_thread_id")]
    public int MessageThreadId { get; set; }

    [QueryParameter("media", IsJson = true)]
    public List<InputMedia> MediaSet { get; set; } = mediaSet;

    [QueryParameter("disable_notification")]
    public bool DisableNotification { get; set; }
    
    [QueryParameter("protect_content")]
    public bool ProtectContent { get; set; }
    
    [QueryParameter("reply_to_message_id")]
    public int ReplyToMessageId { get; set; }
    
    [QueryParameter("allow_sending_without_reply")]
    public bool AllowSendingWithoutReply { get; set; }

    public override IEnumerable<Content> GetContents()
    {
        return MediaSet.Select(media => new Content
        {
            Name = media.Media.Name,
            Value = media.Media.Value.Value,
            MediaType = media.Media.Value.ContentMediaType
        });
    }
}