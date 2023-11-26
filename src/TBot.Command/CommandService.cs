using TBot.CommandProcessor.Abstractions;
using TBot.CommandProcessor.Models;
using TBot.Core.Stores;
using TBot.Core.UpdateEngine;

namespace TBot.CommandProcessor;

public class CommandService : IUpdatePipeline
{
    public string PipelineName => "TBot:Command";

    private readonly ITBotStore _tBotStore;
    private readonly List<ICommandFactory> _commandFactories;

    private string GetStoreKey(long chatId) => $"{PipelineName}:{chatId}";

    public CommandService(ITBotStore tBotStore, IEnumerable<ICommandFactory> commandFactories)
    {
        _tBotStore = tBotStore;
        _commandFactories = commandFactories.ToList();
    }
    
    public async Task<Context> ExecuteAsync(Context context)
    {
        var storeKey = GetStoreKey(context.Session.ChatId);
        var commandContext = (CommandContext)Context.Create(context.Session, context.Update);
        
        Command? command = default;
        if (!await _tBotStore.ContainsAsync(storeKey)) {
            command = await BuildCommandFromStoreAsync(storeKey, commandContext);
        }

        if (command is null && !TryGetCommandFromMessage(context.Update.Message!.Text!, commandContext, out command)) {
            return context.GetCoordinator().ReturnContinued();
        }


        command = await HandleCommandAsync(commandContext, command!);
        await SaveCommandAsync(storeKey, commandContext, command);
        return context.GetCoordinator().ReturnContinued();
    }

    private async Task<Command> HandleCommandAsync(CommandContext commandContext, Command command)
    {
        commandContext = await DoCommandAsync(command.CurrentStep!, commandContext, command.CurrentStepState!.Value);

        if (commandContext.GetCoordinator().Status == Status.Continue)
        {
            switch (command.CurrentStepState)
            {
                case CommandStepState.Action:
                    command.IncrementStepState();
                    return command;
                case CommandStepState.Process:
                    command.IncrementStep();
                    return command;
            }
        }
        else if(commandContext.GetCoordinator().Status == Status.Complete)
        {
            command.SetCommandComplete();
        }
        else if(commandContext.GetCoordinator().Status == Status.Interrupt)
        {
            await DoCommandAsync(command.CurrentStep!, commandContext, CommandStepState.RepeatAction);
        }
        else if(commandContext.GetCoordinator().Status == Status.GoTo)
        {
            command.SetStep(commandContext.GetCoordinator().GoToName!);
        }

        return command;
    }
    
    private bool TryGetCommandFromMessage(string textMassage, CommandContext commandContext, out Command? command)
    {
        command = default;
        var commandFactory = _commandFactories
            .FirstOrDefault(x => x.CommandName == textMassage);

        if (commandFactory is null) {
            return false;
        }

        command = Command.CreateNew(commandFactory.CommandName, commandFactory.CommandSteps, commandContext);
        return true;
    }
    
    private async Task<Command> BuildCommandFromStoreAsync(string storeKey, CommandContext commandContext)
    {
        var storeState = (await _tBotStore.GetAsync<CommandStoreState>(storeKey))!;
        var commandFactory = _commandFactories.FirstOrDefault(
            x => x.CommandName == storeState.CurrentCommandName);

        if (commandFactory is null) {
            throw new Exception($"Command {storeState.CurrentCommandName} is not found");
        }
            
        var step = commandFactory.CommandSteps
            .FirstOrDefault(x => x.StepName == storeState.CurrentStepName);

        if (step is null ) {
            throw new Exception($"Command Step {storeState.CurrentStepName} is not found");
        }

        commandContext.SetState(commandContext.State);
        var stepState = Enum.Parse<CommandStepState>(storeState.StepState);
        
        return Command.Create(
            commandFactory.CommandName,
            step,
            stepState,
            commandFactory.CommandSteps,
            commandContext);
    }

    private async Task<CommandContext> DoCommandAsync(
        BaseCommandStep baseCommandStep, 
        CommandContext commandContext, 
        CommandStepState stepState)
    {
        return stepState switch
        {
            CommandStepState.Action => await baseCommandStep.SendActionRequestAsync(commandContext),
            CommandStepState.Process => await baseCommandStep.ProcessAnswerAsync(commandContext),
            CommandStepState.RepeatAction => await baseCommandStep.SendRepeatActionRequestAsync(commandContext),
            _ => throw new ArgumentException($"Command State {Enum.GetName(stepState)} is not found")
        };
    }

    private Task SaveCommandAsync(string storeKey, CommandContext commandContext, Command command)
    {
        return _tBotStore.SetAsync(storeKey, new CommandStoreState
        {
            State = commandContext.State,
            ChatId = commandContext.Session.ChatId,
            CurrentCommandName = command.Name,
            CurrentStepName = command.CurrentStep!.StepName,
            StepState = Enum.GetName(command.CurrentStepState!.Value)!
        });
    }
}