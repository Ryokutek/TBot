using TBot.Core.TBot.RequestIdentification;
using TBot.LongCommand.Domain;

namespace TBot.LongCommand.Interfaces;

internal interface ICommandStoreService : ILongCommandStoreService
{
    Task<CommandDescriptor> GetCommandDescriptorAsync(long chatId);
    Task<CommandContainer?> GetCommandContainerAsync(long chatId);
    Task SaveCommandAsync(Session session, CommandDescriptor commandDescriptor);
    Task SaveCommandContainerAsync(Session session, CommandContainer commandContainer);
    Task ClearCommandAsync(Session session);
}