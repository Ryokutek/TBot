namespace TBot.Core.RequestOptions.Inputs.Media;

public class MediaAttach
{
    public string Name { get; set; } = null!;
    public InputFile Value { get; set; } = null!;

    public override string ToString()
    {
        return $"attach://{Name}";
    }
}