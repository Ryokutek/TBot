namespace TBot.ReplyKeyboard.KeyboardRepresentation;

public abstract class Component
{
    public virtual Component Get()
    {
        return this;
    }
    
    public virtual bool IsComposite => true;
    
    public virtual void Add(Component component)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Component component)
    {
        throw new NotImplementedException();
    }
}