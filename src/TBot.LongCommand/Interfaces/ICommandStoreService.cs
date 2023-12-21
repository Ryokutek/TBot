using TBot.Core.TBot.RequestIdentification;
using TBot.LongCommand.Domain;

namespace TBot.LongCommand.Interfaces;

public interface ICommandStoreService
{
    Task<bool> IsCommandActiveAsync(long chatId);
    Task<CommandDescriptor> GetCommandDescriptorAsync(long chatId);
    Task<CommandContainer?> GetCommandContainerAsync(long chatId);
    Task SaveCommandAsync(Session session, CommandDescriptor commandDescriptor);
    Task SaveCommandContainerAsync(Session session, CommandContainer commandContainer);
    Task ClearCommandAsync(Session session);
}