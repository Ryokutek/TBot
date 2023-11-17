using TBot.Core.Parameters.Structure;

namespace TBot.Core.Parameters.Webhook;

public class SetWebhookParameters : BaseParameters
{
    [Parameter("url", Required = true)]
    public string Url { get; set; } = null!;
    
    /*[Parameter("certificate", Required = true)]
    public InputFile certificate { get; set; } = null!;*/
    
    [Parameter("ip_address")]
    public string IpAddress { get; set; } = null!;
    
    [Parameter("max_connections")]
    public int MaxConnections { get; set; }
    
    [Parameter("allowed_updates")]
    public string[] AllowedUpdates { get; set; } = null!;
    
    [Parameter("drop_pending_updates")]
    public bool DropPendingUpdates { get; set; }
    
    [Parameter("secret_token")]
    public string SecretToken { get; set; } = null!;
}