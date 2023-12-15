using TBot.Core.TBot;

namespace TBot.Core.RequestOptions.Inputs;

public class StreamFile : InputFile
{
    public override string ContentMediaType => ContentHeaders.MultipartFormData;
    protected internal override object Value => Stream;
    public Stream Stream { get; init; } = null!;
}