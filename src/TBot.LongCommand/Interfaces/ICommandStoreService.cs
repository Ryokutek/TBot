using TBot.Core.TBot.EnvironmentManagement;
using TBot.LongCommand.Domain;

namespace TBot.LongCommand.Interfaces;

internal interface ICommandStoreService : ILongCommandStoreService
{
    Task<CommandDescriptor> GetCommandDescriptorAsync(long chatId);
    Task<CommandContainer?> GetCommandContainerAsync(long chatId);
    Task SaveCommandAsync(UserSession userSession, CommandDescriptor commandDescriptor);
    Task SaveCommandContainerAsync(UserSession userSession, CommandContainer commandContainer);
    Task ClearCommandAsync(UserSession userSession);
}