using Microsoft.Extensions.Logging;
using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.Telegram;
using TBot.Core.UpdateEngine;
using TBot.Core.UpdateEngine.Abstraction;

namespace TBot.Client.Services.UpdateEngine;

public class UpdateEngineService : IUpdateEngineService
{
    private readonly ILogger<IUpdateEngineService> _logger;
    private readonly List<IUpdatePipeline> _pipelines;

    public UpdateEngineService(ILogger<IUpdateEngineService> logger, IEnumerable<IUpdatePipeline> pipelines)
    {
        _logger = logger;
        _pipelines = pipelines.ToList();
    }

    public async Task StartAsync(Update update)
    {
        try
        {
            await ExecuteAsync(update);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "UpdatePipeline processing error. UpdateId: {UpdateId}", update.UpdateId);
        }
    }

    private async Task ExecuteAsync(Update update)
    {
        _logger.LogDebug("UpdatePipeline processing has begun. UpdateId: {UpdateId}", update.UpdateId);
        
        if (_pipelines.Count == 0) {
            return;
        }
        
        var updatePipelineMaster = _pipelines.First();
        var pipelineAdder = updatePipelineMaster;
        for (var i = 1; i < _pipelines.Count; i++)
        {
            pipelineAdder = pipelineAdder.SetNextPipeline(_pipelines[i]);
        }
        
        var context = Context.Create(TBotEnvironment.CurrentRequest!, update);
        await updatePipelineMaster.ExecuteAsync(context);
        _logger.LogDebug("UpdatePipeline processing has been completed. UpdateId: {UpdateId}", update.UpdateId);
    }
}