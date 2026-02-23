using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TBot.Core.ConfigureOptions;
using TBot.Core.LongPolling.Interfaces;
using TBot.Core.RequestOptions;
using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.TBot.Interfaces;
using TBot.Dto.Updates;

namespace TBot.Client.Services.LongPolling;

public sealed class LongPollingService : ILongPollingService
{
    private readonly ILogger<ILongPollingService>? _logger;
    private readonly ITBotClient _botClient;

    private readonly GetUpdateOptions _updateOptions = new();
    private readonly SemaphoreSlim _inflightLimiter;
    private readonly ConcurrentDictionary<ChatUserKey, SemaphoreSlim> _perKeyLocks = new();
    
    private int MaxDegreeOfParallelism { get; set; } = 2;
    private Task? _pollingTask;

    public LongPollingService(
        ILogger<ILongPollingService>? logger,
        ITBotClient botClient,
        IOptions<UpdateOptions> updateOptions)
    {
        _botClient = botClient;
        _logger = logger;

        _updateOptions.Limit = updateOptions.Value.Limit;
        _updateOptions.Timeout = updateOptions.Value.TimeoutSeconds;

        _inflightLimiter = new SemaphoreSlim(
            initialCount: Math.Max(1, MaxDegreeOfParallelism),
            maxCount: Math.Max(1, MaxDegreeOfParallelism));
    }

    public void StartPolling(Func<UpdateDto, Task> updateAction, CancellationToken? cancellationToken = null)
    {
        var ct = cancellationToken ?? CancellationToken.None;
        if (_pollingTask is { IsCompleted: false })
            return;

        _pollingTask = Task.Run(() => ExecuteUpdateLoopAsync(updateAction, ct), ct);
    }

    private async Task ExecuteUpdateLoopAsync(Func<UpdateDto, Task> updateAction, CancellationToken ct)
    {
        var errorDelayMs = 250;
        const int maxErrorDelayMs = 10_000;

        while (!ct.IsCancellationRequested)
        {
            try
            {
                var response = await _botClient.GetUpdateAsync(_updateOptions);

                var updates = response.Result;
                if (updates is null || updates.Count == 0)
                {
                    await Task.Delay(100, ct);
                    errorDelayMs = 250;
                    continue;
                }

                foreach (var update in updates)
                {
                    _updateOptions.Offset = update.UpdateId + 1;

                    await _inflightLimiter.WaitAsync(ct);

                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            await ProcessUpdateSafelyAsync(update, updateAction, ct);
                        }
                        finally
                        {
                            _inflightLimiter.Release();
                        }
                    }, ct);
                }

                errorDelayMs = 250;
            }
            catch (OperationCanceledException) when (ct.IsCancellationRequested)
            {
                return;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "LongPolling loop error. Will continue polling.");
                await Task.Delay(errorDelayMs, ct);
                errorDelayMs = Math.Min(maxErrorDelayMs, errorDelayMs * 2);
            }
        }
    }

    private async Task ProcessUpdateSafelyAsync(UpdateDto update, Func<UpdateDto, Task> updateAction, CancellationToken ct)
    {
        _logger?.LogDebug("Received update. UpdateId: {UpdateId}", update.UpdateId);

        var key = ChatUserKey.From(update);
        var gate = _perKeyLocks.GetOrAdd(key, static _ => new SemaphoreSlim(1, 1));

        await gate.WaitAsync(ct);
        try
        {
            using (TBotEnvironment.SetRequest(update.ToSession()))
            {
                try
                {
                    await updateAction(update);
                }
                catch (Exception ex)
                {
                    _logger?.LogWarning(ex,
                        "Update processing failed. Ignored. UpdateId: {UpdateId}, ChatId: {ChatId}, UserId: {UserId}",
                        update.UpdateId, key.ChatId, key.UserId);
                }
            }
        }
        finally
        {
            gate.Release();
        }
    }

    private readonly record struct ChatUserKey(long ChatId, long UserId)
    {
        public static ChatUserKey From(UpdateDto update)
        {
            var chatId = update.Message?.Chat.Id ?? update.CallbackQuery?.From.Id ?? 0;
            var userId = update.Message?.From?.Id ?? update.CallbackQuery?.From.Id ?? 0;
            return new ChatUserKey(chatId, userId);
        }
    }
}