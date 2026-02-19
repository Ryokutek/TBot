using TBot.Client.Asp.Extensions;
using TestApp;

var builder = WebApplication.CreateBuilder(args);

builder.AddTBot(botBuilder => botBuilder
    .AddLongPolling()
    .AddUpdateEngine()
    .AddTrigger<WelcomeTrigger>()
);

var app = builder.Build();

app.RunTBot().WithUpdateEngine();
app.MapGet("/", () => "Hello World!");

await app.RunAsync();