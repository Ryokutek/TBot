﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TBot.Core.Builders;
using TBot.Core.Stores;
using TBot.Core.TBot;
using TBot.ReplyKeyboard.Models;

namespace TBot.ReplyKeyboard;

public static class Extensions
{
    public static UpdateEngineBuilder AddReplyKeyboardPipeline(this UpdateEngineBuilder updateEngineBuilder)
    {
        updateEngineBuilder.Services.AddOptions<ReplyKeyboardModel>(updateEngineBuilder.Configuration, "TBotOptions:ReplyKeyboardModel");
        return updateEngineBuilder.AddService<ReplyKeyboardService>(provider =>
        {
            using var scope = provider.CreateScope();
            var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<ReplyKeyboardModel>>();
            var client = provider.GetRequiredService<ITBotClient>();
            var store = provider.GetService<ITBotStore>();
            var logger = provider.GetService<ILogger<ReplyKeyboardService>>();

            return new ReplyKeyboardService(logger, options.Value, client, store);
        });
    }
    
    public static UpdateEngineBuilder AddReplyKeyboardPipeline(
        this UpdateEngineBuilder updateEngineBuilder, 
        ReplyKeyboardModel replyKeyboardModel)
    {
        return updateEngineBuilder.AddService<ReplyKeyboardService>(provider =>
        {
            var client = provider.GetRequiredService<ITBotClient>();
            var store = provider.GetService<ITBotStore>();
            var logger = provider.GetService<ILogger<ReplyKeyboardService>>();

            return new ReplyKeyboardService(logger, replyKeyboardModel, client, store);
        });
    }
    
    public static UpdateEngineBuilder AddReplyKeyboardPipeline(
        this UpdateEngineBuilder updateEngineBuilder, 
        Func<IServiceProvider, ReplyKeyboardModel> replyKeyboardModel)
    {
        return updateEngineBuilder.AddService<ReplyKeyboardService>(provider =>
        {
            var client = provider.GetRequiredService<ITBotClient>();
            var store = provider.GetService<ITBotStore>();
            var logger = provider.GetService<ILogger<ReplyKeyboardService>>();

            return new ReplyKeyboardService(logger, replyKeyboardModel(provider), client, store);
        });
    }
}