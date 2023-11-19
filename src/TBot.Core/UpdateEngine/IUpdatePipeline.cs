namespace TBot.Core.UpdateEngine;

public interface IUpdatePipeline
{
    public string PipelineName { get; }
    Task<PipelineContext> ExecuteAsync(PipelineContext context);
}