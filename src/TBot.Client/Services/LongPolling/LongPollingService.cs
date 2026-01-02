using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TBot.Core.ConfigureOptions;
using TBot.Core.LongPolling.Interfaces;
using TBot.Core.RequestOptions;
using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.TBot.Interfaces;
using TBot.Dto.Updates;

namespace TBot.Client.Services.LongPolling;

public class LongPollingService : ILongPollingService
{
    private readonly ILogger<ILongPollingService>? _logger;
    private readonly ITBotClient _botClient;
    private GetUpdateOptions UpdateOptions { get; set; } = new ();

    public LongPollingService(
        ILogger<ILongPollingService>? logger, 
        ITBotClient botClient, 
        IOptions<UpdateOptions> updateOptions)
    {
        _botClient = botClient;
        _logger = logger;
        UpdateOptions.Limit = updateOptions.Value.Limit;
        UpdateOptions.Timeout = updateOptions.Value.TimeoutSeconds;
    }
    
    public void StartPolling(Func<UpdateDto, Task> updateAction, CancellationToken? cancellationToken = null)
    {
        Task.Factory.StartNew(async () =>
        {
            try
            {
                await ExecuteUpdateAsync(updateAction, cancellationToken);
            }
            catch (Exception e)
            {
                _logger?.LogCritical(e, "Update error.");
            }
        });
    }

    private async Task ExecuteUpdateAsync(Func<UpdateDto, Task> updateAction, CancellationToken? cancellationToken)
    {
        while (true)
        {
            if (cancellationToken?.IsCancellationRequested == true)
                return;

            var response = await _botClient.GetUpdateAsync(UpdateOptions);
            if (response.Result is null)
                continue;

            foreach (var update in response.Result)
            {
                _logger?.LogDebug("Received an update from Telegram. UpdateId: {UpdateId}", update.UpdateId);
                using (TBotEnvironment.SetRequest(update.ToSession()))
                {
                    await updateAction(update);
                }
                
                UpdateOptions.Offset = update.UpdateId + 1;
            }
        }
    }
}