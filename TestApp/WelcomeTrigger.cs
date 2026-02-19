using TBot.Core.UpdateEngine;

namespace TestApp;

public class WelcomeTrigger : SyncUpdateTrigger<WelcomeHandler>
{
    protected override bool Check(UpdateContext context)
    {
        return true;
    }
}