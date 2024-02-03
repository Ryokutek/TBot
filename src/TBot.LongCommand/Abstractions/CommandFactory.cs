﻿using Microsoft.Extensions.DependencyInjection;
using TBot.Core.Telegram;
using TBot.LongCommand.Domain;
using TBot.LongCommand.Interfaces;

namespace TBot.LongCommand.Abstractions;

public class CommandFactory : ICommandFactory, IDisposable
{
    private bool _disposed;
    private readonly IServiceScope _serviceScope;
    private readonly List<CommandRepresentation> _commands;

    public CommandFactory(
        IServiceProvider serviceProvider, 
        List<CommandRepresentation> commands)
    {
        _commands = commands;
        _serviceScope = serviceProvider.CreateScope();
    }

    public CommandRepresentation? GetCommandIfExists(Update update)
    {
        return _commands.FirstOrDefault(x => x.CommandTrigger(update));
    }
    
    public CommandPart CreateCommandPart(CommandRepresentation commandRepresentation, int partNumber)
    {
        var type = commandRepresentation.CommandParts[partNumber].Type;
        return (CommandPart)ActivatorUtilities.CreateInstance(_serviceScope.ServiceProvider, type);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _serviceScope.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}