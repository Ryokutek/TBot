using TBot.Core.TBot.EnvironmentManagement;
using TBot.LongCommand.Domain;

namespace TBot.LongCommand.Interfaces;

internal interface ICommandStoreService : ILongCommandStoreService
{
    Task<CommandDescriptor> GetCommandDescriptorAsync(long chatId);
    Task<CommandContainer?> GetCommandContainerAsync(long chatId);
    Task SaveCommandAsync(CurrentRequest currentRequest, CommandDescriptor commandDescriptor);
    Task SaveCommandContainerAsync(CurrentRequest currentRequest, CommandContainer commandContainer);
    Task ClearCommandAsync(CurrentRequest currentRequest);
}