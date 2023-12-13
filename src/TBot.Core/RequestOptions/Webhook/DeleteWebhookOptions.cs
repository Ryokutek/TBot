using TBot.Core.RequestOptions.Structure;

namespace TBot.Core.RequestOptions.Webhook;

public class DeleteWebhookOptions : BaseOptions
{
    [QueryParameter("drop_pending_updates")]
    public bool DropPendingUpdates { get; set; }
}