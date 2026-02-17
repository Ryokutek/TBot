using TBot.Core.UpdateEngine;

namespace TestApp;

public class UpdateTrigger : IUpdateTrigger
{
    public Task<(bool, Type)> CheckAsync(UpdateContext context)
    {
        return Task.FromResult((context.UpdateDto.Message!.Text == "a", typeof(UpdateHandler)));
    }
}