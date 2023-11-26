using TBot.Core.Builders;

namespace TBot.CommandProcessor;

public static class Extensions
{
    public static CommandServiceBuilder AddCommandService(this UpdateEngineBuilder updateEngineBuilder)
    {
        updateEngineBuilder.AddService<CommandService>();
        return new CommandServiceBuilder(updateEngineBuilder, updateEngineBuilder.Services);
    }
}