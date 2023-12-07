using Microsoft.Extensions.Logging;
using TBot.Core.TBot.RequestIdentification;
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
        if (!_pipelines.Any()) {
            return;
        }
        
        var updatePipelineMaster = new UpdatePipeline().SetNextPipeline(_pipelines.First());
        for (int i = 1; i < _pipelines.Count; i++)
        {
            updatePipelineMaster.SetNextPipeline(_pipelines[i]);
        }
        
        var context = Context.Create(CurrentSessionThread.Session ?? throw new Exception(), update);
        await updatePipelineMaster.ExecuteAsync(context);
    }
}