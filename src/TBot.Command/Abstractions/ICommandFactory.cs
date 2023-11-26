namespace TBot.CommandProcessor.Abstractions;

public interface ICommandFactory
{
    public string CommandName { get; }
    public List<BaseCommandStep> CommandSteps { get; set; }
}