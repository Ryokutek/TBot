using TBot.Core.Parameters.Structure;

namespace TBot.Core.Parameters.Webhook;

public class DeleteWebhookParameters : BaseParameters
{
    [Parameter("drop_pending_updates")]
    public bool DropPendingUpdates { get; set; }
}