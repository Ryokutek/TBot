using TBot.Asp.Client;
using TBot.Core.UpdateEngine;
using TestApp;

var builder = WebApplication.CreateBuilder(args);

builder.AddTBot(botBuilder => botBuilder.AddLongPolling().AddUpdateEngine());
builder.Services.AddScoped<IUpdateTrigger, UpdateTrigger>();

var app = builder.Build();

app.RunTBot().WithUpdateEngine();
app.MapGet("/", () => "Hello World!");

await app.RunAsync();