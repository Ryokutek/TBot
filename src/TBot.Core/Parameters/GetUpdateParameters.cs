using TBot.Core.Parameters.Structure;

namespace TBot.Core.Parameters;

public class GetUpdateParameters : BaseParameters
{
    [Parameter("offset")]
    public int Offset { get; set; }

    [Parameter("limit")] 
    public int Limit { get; set; } = Constants.Update.Limit;

    [Parameter("timeout")] 
    public int Timeout { get; set; } = Constants.Update.Timeout;

    [Parameter("allowed_updates", IsJson = true)] 
    public List<string> AllowedUpdates { get; set; } = new ();
}