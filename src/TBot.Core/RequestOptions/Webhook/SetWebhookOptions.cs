using TBot.Core.RequestOptions.Structure;

namespace TBot.Core.RequestOptions.Webhook;

public class SetWebhookOptions : BaseOptions
{
    public SetWebhookOptions(string url)
    {
        Url = url;
    }
    
    [QueryParameter("url", Required = true)]
    public string Url { get; set; }
    
    /*[Parameter("certificate", Required = true)]
    public InputFile certificate { get; set; } = null!;*/
    
    [QueryParameter("ip_address")]
    public string IpAddress { get; set; } = null!;
    
    [QueryParameter("max_connections")]
    public int MaxConnections { get; set; }
    
    [QueryParameter("allowed_updates")]
    public string[] AllowedUpdates { get; set; } = null!;
    
    [QueryParameter("drop_pending_updates")]
    public bool DropPendingUpdates { get; set; }
    
    [QueryParameter("secret_token")]
    public string SecretToken { get; set; } = null!;
}