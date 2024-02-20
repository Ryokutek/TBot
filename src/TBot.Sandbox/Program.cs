using Serilog;
using TBot.Asp.Client;
using TBot.Sandbox.Pipelines;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.AddTBot(botBuilder =>
{
    botBuilder
        //.AddLongPoll()
        .AddRedisStore("localhost,password=password,defaultDatabase=1,syncTimeout=3000")
        .EnableCallLimiter()
        .AddUpdateServices()
        .AddService<GreetingPipeline>();
});


var app = builder.Build();

//app.RunTBot().WithUpdateEngine();
app.UseTBotRoute().WithUpdateEngine();

await app.RunAsync();