using TBot.Core.UpdateEngine;

namespace TBot.Pipeline.LongTermCommand.Interfaces;

public interface ILongTermCommandFactory
{
    Task<(bool, LongTermCommand? longTermCommand)> TryGetLongTermCommandAsync(PipelineContext pipelineContext);
}