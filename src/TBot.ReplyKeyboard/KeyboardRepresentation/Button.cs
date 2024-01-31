namespace TBot.ReplyKeyboard.KeyboardRepresentation;

public class Button : Component
{
    public override bool IsComposite => false;

    public string Text { get; set; } = null!;
    public bool IsEnable { get; set; } = true;
    public bool IsBack { get; set; } = false;
    public int Index { get; set; }
    public int Line { get; set; }
}