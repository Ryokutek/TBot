using Microsoft.Extensions.Options;
using TBot.Core.LongPolling;
using TBot.Core.Options;
using TBot.Core.Parameters;
using TBot.Core.TBot;
using TBot.Core.TBot.RequestIdentification;
using TBot.Core.Telegram;

namespace TBot.Client.Services.LongPolling;

public class LongPollingService : ILongPollingService
{
    private readonly ITBotClient _botClient;
    private GetUpdateParameters UpdateParameters { get; set; } = new ();

    public LongPollingService(ITBotClient botClient, IOptions<UpdateOptions>? updateOptions = null)
    {
        _botClient = botClient;
        if (updateOptions is null) {
            return;
        }
        
        UpdateParameters.Limit = updateOptions.Value.Limit;
        UpdateParameters.Timeout = updateOptions.Value.TimeoutSeconds;
    }
    
    public void Start(Func<Update, Task> updateAction, CancellationToken? cancellationToken = null)
    {
        Task.Factory.StartNew(async () =>
        {
            while (true)
            {
                if (cancellationToken?.IsCancellationRequested == true)
                {
                    return;
                }

                var response = await _botClient.GetUpdateAsync(UpdateParameters);
                if (!response.Result.Any())
                {
                    continue;
                }

                foreach (var updateDto in response.Result)
                {
                    using (CurrentSessionThread.SetSession(Session.Create(Guid.NewGuid(), updateDto.Message!.Chat.Id)))
                    {
                        await updateAction(updateDto);
                    }
                    
                    UpdateParameters.Offset = updateDto.UpdateId + 1;
                }
            }
        });
    }
}