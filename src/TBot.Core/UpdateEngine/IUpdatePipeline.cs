namespace TBot.Core.UpdateEngine;

public interface IUpdatePipeline
{
    public string PipelineName { get; }
    Task<Context> ExecuteAsync(Context context);
}