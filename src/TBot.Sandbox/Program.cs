using Serilog;
using Serilog.Context;
using Serilog.Templates;
using Serilog.Templates.Themes;
using TBot.AspNet.Client;
using TBot.Sandbox.Pipelines;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console(new ExpressionTemplate(
            "[{@t:HH:mm:ss} {@l:u3}{#if SessionId is not null} {SessionId}{#end} {SourceContext}] {@m}\n{@x}", theme: TemplateTheme.Code)));

builder.AddTBot(botBuilder =>
{
    botBuilder
        .AddLongPoll()
        .AddRedisStore("localhost,password=password,defaultDatabase=1,syncTimeout=3000")
        .EnableCallLimiter()
        .AddUpdateServices()
        .AddService<GreetingPipeline>()
        .AddService<ManyRequestSenderPipeline>();
});


var app = builder.Build();

app.Logger.LogInformation("Hi1");
using (LogContext.PushProperty("SessionId", Guid.NewGuid()))
{
    app.Logger.LogInformation("Hi");
}

app.RunTBot().WithUpdateEngine();
//app.UseTBotRoute().WithUpdateEngine();

await app.RunAsync();