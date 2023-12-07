namespace TBot.Core.UpdateEngine.Abstraction;

public interface IUpdatePipeline
{
    IUpdatePipeline SetNextPipeline(IUpdatePipeline updatePipeline);
    Task<Context> ExecuteAsync(Context context);
}