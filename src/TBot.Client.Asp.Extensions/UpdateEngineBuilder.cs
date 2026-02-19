using Microsoft.Extensions.DependencyInjection;
using TBot.Core.UpdateEngine;
using TBot.Core.UpdateEngine.Interfaces;

namespace TBot.Client.Asp.Extensions;

public class UpdateEngineBuilder(IServiceCollection serviceCollection)
{
    public UpdateEngineBuilder AddTrigger<TTrigger>() where TTrigger : class, IUpdateTrigger
    {
        serviceCollection.AddScoped<IUpdateTrigger, TTrigger>();
        return this;
    }
}