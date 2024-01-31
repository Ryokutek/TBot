namespace TBot.ReplyKeyboard.KeyboardRepresentation;

public class Keyboard : Component
{
    public string Name { get; set; } = null!;
    public readonly List<Component> Buttons = new ();

    public override void Add(Component component)
    {
        Buttons.Add(component);
    }

    public override void Remove(Component component)
    {
        Buttons.Remove(component);
    }
}