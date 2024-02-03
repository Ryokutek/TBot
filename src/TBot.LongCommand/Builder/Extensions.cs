using Microsoft.Extensions.DependencyInjection;
using TBot.Core.Builders;
using TBot.LongCommand.Interfaces;

namespace TBot.LongCommand.Builder;

public static class Extensions
{
    public static CommandServiceBuilder AddCommandService(this UpdateEngineBuilder updateEngineBuilder)
    {
        updateEngineBuilder.AddService<CommandService>();
        updateEngineBuilder.Services.AddTransient<ICommandStoreService, CommandStoreService>();
        updateEngineBuilder.Services.AddTransient<ILongCommandStoreService, CommandStoreService>();
        return new CommandServiceBuilder(updateEngineBuilder, updateEngineBuilder.Services);
    }
}