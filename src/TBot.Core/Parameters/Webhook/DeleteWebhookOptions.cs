using TBot.Core.Parameters.Structure;

namespace TBot.Core.Parameters.Webhook;

public class DeleteWebhookOptions : BaseOptions
{
    [QueryParameter("drop_pending_updates")]
    public bool DropPendingUpdates { get; set; }
}