namespace TBot.LongCommand.Interfaces;

public interface ILongCommandStoreService
{
    Task<bool> IsCommandActiveAsync(long chatId, string? commandIdentifier = null);
}