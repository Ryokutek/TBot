using Microsoft.Extensions.DependencyInjection;
using TBot.Command.Interfaces;
using TBot.Core.Builders;

namespace TBot.Command.Builder;

public static class Extensions
{
    public static CommandServiceBuilder AddCommandService(this UpdateEngineBuilder updateEngineBuilder)
    {
        updateEngineBuilder.AddService<CommandService>();
        updateEngineBuilder.Services.AddTransient<ICommandStoreService, CommandStoreService>();
        return new CommandServiceBuilder(updateEngineBuilder, updateEngineBuilder.Services);
    }
}