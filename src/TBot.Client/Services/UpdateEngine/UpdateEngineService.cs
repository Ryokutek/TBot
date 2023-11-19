using Microsoft.Extensions.Logging;
using TBot.Core.Telegram;
using TBot.Core.UpdateEngine;

namespace TBot.Client.Services.UpdateEngine;

public class UpdateEngineService : IUpdateEngineService
{
    private readonly ILogger<IUpdateEngineService> _logger;
    private readonly IEnumerable<IUpdatePipeline> _pipelines;

    public UpdateEngineService(ILogger<IUpdateEngineService> logger, IEnumerable<IUpdatePipeline> pipelines)
    {
        _logger = logger;
        _pipelines = pipelines;
    }

    public async Task StartAsync(Update update)
    {
        var pipelines = _pipelines.ToList();
        var context = PipelineContext.Create(update);
        
        string? nextPipeline = null;
        var currentPipeline = string.Empty;
        
        for (var i = 0; i < pipelines.Count; i++)
        {
            try
            {
                if (!string.IsNullOrEmpty(nextPipeline)) {
                    i = pipelines.FindIndex(pipeline => pipeline.PipelineName == nextPipeline);
                }

                var pipeline = pipelines[i];
                currentPipeline = pipeline.PipelineName;
                context = await pipeline.ExecuteAsync(context);

                switch (context.GetCoordinator().PipelineStatus)
                {
                    case PipelineStatus.Interrupt or PipelineStatus.Continue: continue;
                    case PipelineStatus.Complete: return;
                    case PipelineStatus.GoTo: break;
                }
            }
            catch (Exception e)
            {
                _logger?.LogError(e, "UpdatePipeline has crashed. PipelineName: {PipelineName}", currentPipeline);
                context.GetCoordinator().WithStatus(PipelineStatus.Interrupt);
            }
        }
    }
}