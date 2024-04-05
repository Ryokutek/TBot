namespace TBot.Core.UpdateEngine.Abstraction;

public interface IUpdatePipeline
{
    IUpdatePipeline SetNextPipeline(IUpdatePipeline updatePipeline);
    Task<PipelineContext> ExecuteAsync(PipelineContext pipelineContext);
}