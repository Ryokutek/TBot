using TBot.CommandProcessor.Abstractions;

namespace TBot.CommandProcessor.Models;

public class Command
{
    public string Name { get; set; }
    public bool IsComplete { get; set; }
    public BaseCommandStep? CurrentStep { get; set; }
    public CommandStepState? CurrentStepState { get; set; }
    
    public List<BaseCommandStep> Steps { get; set; }
    public CommandContext CommandContext { get; set; }
    
    private Command(
        string name, 
        BaseCommandStep? currentStep, 
        CommandStepState? currentStepState, 
        List<BaseCommandStep> steps,
        CommandContext commandContext)
    {
        Name = name;
        CurrentStep = currentStep;
        CurrentStepState = currentStepState;
        Steps = steps;
        CommandContext = commandContext;
    }

    public static Command CreateNew(string name, List<BaseCommandStep> steps, CommandContext commandContext)
    {
        return new Command(
            name,
            steps.First(),
            CommandStepState.Action,
            steps,
            commandContext);
    }
    
    public static Command Create(
        string name, 
        BaseCommandStep? currentStep, 
        CommandStepState? currentStepState, 
        List<BaseCommandStep> steps,
        CommandContext commandContext)
    {
        return new Command(
            name,
            currentStep,
            currentStepState,
            steps,
            commandContext);
    }

    public void IncrementStepState()
    {
        CurrentStepState++;
    }
    
    public void IncrementStep()
    {
        var stepIndex = Steps.FindIndex(x => x.StepName == CurrentStep!.StepName);
        if (stepIndex != Steps.Count - 1) {
            CurrentStep = Steps[stepIndex + 1];
            return;
        }

        SetCommandComplete();
    }

    public void SetCommandComplete()
    {
        IsComplete = true;
    }

    public void SetStep(string stepName)
    {
        CurrentStep = Steps.First(x => x.StepName == stepName);
    }
}