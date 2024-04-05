using Microsoft.Extensions.DependencyInjection;
using TBot.Core.UpdateEngine;
using TBot.Pipeline.LongTermCommand.Interfaces;
using TBot.Pipeline.LongTermCommand.Models;

namespace TBot.Pipeline.LongTermCommand;

public class LongTermCommandFactory(
    IServiceScope serviceScope, 
    ILongTermCommandStore longTermCommandStore,
    List<LongTermCommandScenario> scenarios) : ILongTermCommandFactory
{
    private List<LongTermCommandScenario> Scenarios { get; set; } = scenarios;
    
    public async Task<(bool, LongTermCommand? longTermCommand)> TryGetLongTermCommandAsync(PipelineContext pipelineContext)
    {
        LongTermCommand? longTermCommand;
        if (!await longTermCommandStore.IsLongTermCommandExistsAsync(pipelineContext.CurrentRequest))
        {
            if (TryGetLongTermCommand(pipelineContext, out longTermCommand))
            {
                return (true, longTermCommand);
            }
        }
        else
        {
            var longTermCommandEntity = await longTermCommandStore.GetLongTermCommandAsync(pipelineContext.CurrentRequest);
            var scenario = Scenarios.First(x => x.Identifier == longTermCommandEntity.Identifier);
            longTermCommand = new LongTermCommand(scenario.Identifier, 
                InitCommandSegments(scenario.Segments, pipelineContext, new Models.Storage(longTermCommandEntity.IntermediateData ?? string.Empty)).ToList());
            longTermCommand.SetCurrentSegment(longTermCommandEntity.SegmentNumber);
            return (true, longTermCommand); 
        }

        return (false, default);
    }

    private bool TryGetLongTermCommand(PipelineContext pipelineContext, out LongTermCommand? longTermCommand)
    {
        longTermCommand = null;
        var foundScenario = Scenarios.FirstOrDefault(scenario => scenario.Triggers.Any(trigger => trigger.Invoke(pipelineContext.Update)));
        if (foundScenario is null) {
            return false;
        }

        var commandSegments = 
            InitCommandSegments(foundScenario.Segments, pipelineContext, new Models.Storage(string.Empty)).ToList();

        longTermCommand = new LongTermCommand(foundScenario.Identifier, commandSegments);
        return true;
    }
    
    private IEnumerable<CommandSegment> InitCommandSegments(
        IEnumerable<Type> segmentTypes, PipelineContext pipelineContext, Models.Storage storage)
    {
        return segmentTypes.Select(segmentType => 
            (CommandSegment)ActivatorUtilities.CreateInstance(serviceScope.ServiceProvider, segmentType, 
                pipelineContext.Update, pipelineContext.CurrentRequest, storage));
    }
}