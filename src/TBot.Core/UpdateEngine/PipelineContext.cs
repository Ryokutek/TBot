using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.Telegram;

namespace TBot.Core.UpdateEngine;

public class PipelineContext
{
    public CurrentRequest CurrentRequest { get; private set; }
    public Update Update { get; private set; }

    protected PipelineContext(CurrentRequest currentRequest, Update update)
    {
        CurrentRequest = currentRequest;
        Update = update;
    }

    public static PipelineContext Create(CurrentRequest currentRequest, Update update)
    {
        return new PipelineContext(currentRequest, update);
    }
}