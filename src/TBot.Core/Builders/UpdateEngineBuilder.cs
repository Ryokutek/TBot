using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TBot.Core.UpdateEngine;

namespace TBot.Core.Builders;

public class UpdateEngineBuilder
{
    public IServiceCollection Services { get; private set; }
    public IConfiguration Configuration { get; private set; }

    public UpdateEngineBuilder(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        Services = serviceCollection;
        Configuration = configuration;
    }

    public UpdateEngineBuilder AddService<TUpdatePipeline>() where TUpdatePipeline : class, IUpdatePipeline
    {
        Services.AddTransient<IUpdatePipeline, TUpdatePipeline>();
        return this;
    }
    
    public UpdateEngineBuilder AddService<TUpdatePipeline>(Func<IServiceProvider, TUpdatePipeline> implementationFactory) where TUpdatePipeline : class, IUpdatePipeline
    {
        Services.AddTransient<IUpdatePipeline>(implementationFactory);
        return this;
    }
}