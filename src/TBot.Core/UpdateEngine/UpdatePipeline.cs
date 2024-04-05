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

    public async Task<PipelineContext> ExecuteNextAsync(PipelineContext pipelineContext)
    {
        return _nextPipeline is not null 
            ? await _nextPipeline.ExecuteAsync(pipelineContext) 
            : pipelineContext;
    }
    
    public virtual async Task<PipelineContext> ExecuteAsync(PipelineContext pipelineContext)
    {
        return _nextPipeline is not null 
            ? await _nextPipeline.ExecuteAsync(pipelineContext) 
            : pipelineContext;
    }
}