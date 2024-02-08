using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TBot.Client.Utilities;
using TBot.Core.ConfigureOptions;
using TBot.Core.LongPolling;
using TBot.Core.RequestOptions;
using TBot.Core.TBot;
using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.Telegram;

namespace TBot.Client.Services.LongPolling;

public class LongPollingService : ILongPollingService
{
    private readonly ILogger<ILongPollingService> _logger;
    private readonly ITBotClient _botClient;
    private GetUpdateOptions UpdateOptions { get; set; } = new ();

    public LongPollingService(
        ILogger<ILongPollingService> logger, 
        ITBotClient botClient, 
        IOptions<UpdateOptions>? updateOptions = null)
    {
        _botClient = botClient;
        _logger = logger;
        
        if (updateOptions is null) {
            return;
        }
        
        UpdateOptions.Limit = updateOptions.Value.Limit;
        UpdateOptions.Timeout = updateOptions.Value.TimeoutSeconds;
    }
    
    public void Start(Func<Update, Task> updateAction, CancellationToken? cancellationToken = null)
    {
        Task.Factory.StartNew(async () =>
        {
            try
            {
                await ExecuteUpdateAsync(updateAction, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "TBot. An error occurred while processing the getting update.");
            }
        });
    }

    private async Task ExecuteUpdateAsync(Func<Update, Task> updateAction, CancellationToken? cancellationToken)
    {
        while (true)
        {
            if (cancellationToken?.IsCancellationRequested == true)
            {
                return;
            }

            var response = await _botClient.GetUpdateAsync(UpdateOptions);
            if (response.Result is null)
            {
                continue;
            }

            foreach (var update in response.Result)
            {
                using (TBotEnvironment.SetSession(update.ToSession()))
                {
                    await updateAction(update);
                }
                
                UpdateOptions.Offset = update.UpdateId + 1;
            }
        }
    }
}