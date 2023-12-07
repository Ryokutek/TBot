using TBot.Core.UpdateEngine.Abstraction;

namespace TBot.Core.UpdateEngine;

public class UpdatePipeline : IUpdatePipeline
{
    private IUpdatePipeline? _nextPipeline;

    public IUpdatePipeline SetNextPipeline(IUpdatePipeline updatePipeline)
    {
        _nextPipeline = updatePipeline;
        return updatePipeline;
    }

    public async Task<Context> ExecuteNextAsync(Context context)
    {
        return _nextPipeline is not null 
            ? await _nextPipeline.ExecuteAsync(context) 
            : context;
    }
    
    public virtual async Task<Context> ExecuteAsync(Context context)
    {
        return _nextPipeline is not null 
            ? await _nextPipeline.ExecuteAsync(context) 
            : context;
    }
}