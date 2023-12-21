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
        return new CommandServiceBuilder(updateEngineBuilder, updateEngineBuilder.Services);
    }
}