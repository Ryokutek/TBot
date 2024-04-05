using TBot.Core.TBot.EnvironmentManagement;

namespace TBot.Pipeline.LongTermCommand.Interfaces;

public interface ILongTermCommandStore
{
    Task<bool> IsLongTermCommandExistsAsync(CurrentRequest currentRequest);
    Task<Models.LongTermCommand> GetLongTermCommandAsync(CurrentRequest currentRequest);
    Task SaveLongTermCommandAsync(CurrentRequest currentRequest, Models.LongTermCommand longTermCommand);
    Task ClearCommandAsync(CurrentRequest currentRequest);
}