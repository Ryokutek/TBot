using TBot.CommandProcessor.Models;

namespace TBot.CommandProcessor.Abstractions;

public abstract class BaseCommandStep
{
    public abstract string StepName { get; set; }
    
    protected CommandContext CommandContext { get; init; }
    protected CommandCoordinator CommandCoordinator => (CommandCoordinator)CommandContext.GetCoordinator();
    
    public abstract Task<CommandContext> SendActionRequestAsync(CommandContext context);
    public abstract Task<CommandContext> ProcessAnswerAsync(CommandContext context);
    public abstract Task<CommandContext> SendRepeatActionRequestAsync(CommandContext context);

    public CommandContext ReturnCompleted()
    {
        return (CommandContext)CommandCoordinator.ReturnCompleted();
    }
    
    public CommandContext ReturnContinued()
    {
        return (CommandContext)CommandCoordinator.ReturnContinued();
    } 
    
    public CommandContext ReturnInterrupted()
    {
        return (CommandContext)CommandCoordinator.ReturnInterrupted();
    } 
    
    public CommandContext GoTo(string stepName)
    {
        return (CommandContext)CommandCoordinator.GoTo(stepName);
    } 
}