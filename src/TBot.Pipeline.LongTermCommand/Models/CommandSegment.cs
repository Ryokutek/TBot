using TBot.Core.UpdateEngine;

namespace TBot.Pipeline.LongTermCommand.Models;

public abstract class CommandSegment
{
    protected PipelineContext PipelineContext { get; private set;}
    public Storage Storage { get; private set; }

    protected CommandSegment(PipelineContext pipelineContext, Storage container)
    {
        PipelineContext = pipelineContext;
        Storage = container;
    }

    public abstract Task SendActionRequestAsync();
    public abstract Task<ProcessAnswerStatus> ProcessAnswerAsync();
    public virtual Task OnProcessAnswerFailAsync(Exception? exception = null)
    {
        return Task.CompletedTask;
    }
    public virtual Task OnClarificationIsNecessaryAsync()
    {
        return Task.CompletedTask;
    }
}