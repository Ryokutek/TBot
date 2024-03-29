﻿using TBot.Core.RequestOptions.Structure;

namespace TBot.Core.RequestOptions;

public class GetUpdateOptions : BaseOptions
{
    [QueryParameter("offset")]
    public int Offset { get; set; }

    [QueryParameter("limit")] 
    public int Limit { get; set; } = Constants.UpdateSettings.Limit;

    [QueryParameter("timeout")] 
    public int Timeout { get; set; } = Constants.UpdateSettings.Timeout;

    [QueryParameter("allowed_updates", IsJson = true)] 
    public List<string> AllowedUpdates { get; set; } = new ();
}