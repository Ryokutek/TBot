using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.UpdateEngine;
using TBot.Pipeline.LongTermCommand.Interfaces;
using TBot.Pipeline.LongTermCommand.Models;

namespace TBot.Pipeline.LongTermCommand;

public class LongTermCommandPipeline(
    ILongTermCommandFactory commandFactory,
    ILongTermCommandStore store) : UpdatePipeline
{
    public override async Task<PipelineContext> ExecuteAsync(PipelineContext pipelineContext)
    {
        var (isExists, longTermCommand) = await commandFactory.TryGetLongTermCommandAsync(pipelineContext);
        if (!isExists) {
            return await ExecuteNextAsync(pipelineContext);
        }

        await HandleAsync(pipelineContext.CurrentRequest, longTermCommand!);
        return await ExecuteNextAsync(pipelineContext);
    }

    private async Task HandleAsync(CurrentRequest currentRequest, LongTermCommand longTermCommand)
    {
        if (longTermCommand.CurrentSegmentNumber == -1)
        {
            await longTermCommand.Segments[0].SendActionRequestAsync();
            longTermCommand.IncreaseSegmentNumber();
        }

        var commandSegment = longTermCommand.GetCurrentSegment();
        try
        {
            var status = await commandSegment.ProcessAnswerAsync();
            switch (status)
            {
                case ProcessAnswerStatus.Completed: 
                    longTermCommand.IncreaseSegmentNumber();
                    await longTermCommand.GetCurrentSegment().SendActionRequestAsync();
                    break;
                case ProcessAnswerStatus.ForceFail: await commandSegment.OnProcessAnswerFailAsync(); break;
                case ProcessAnswerStatus.ClarificationNecessary: await commandSegment.OnClarificationIsNecessaryAsync(); break;
            }
        }
        catch (Exception exception)
        {
            await commandSegment.OnProcessAnswerFailAsync(exception);
        }

        var longTermCommandEntity = Models.LongTermCommand.Create(currentRequest, longTermCommand, commandSegment.Storage.ToString());
        await store.SaveLongTermCommandAsync(currentRequest,longTermCommandEntity);
    }
}