using TBot.Core.TBot;

namespace TBot.Core.RequestOptions.InputFileParameters;

public class StringIdentifierFile : InputFile
{
    public override string ContentMediaType => ContentHeaders.TextPlain;
    protected internal override object Value => StringIdentifier;
    public string StringIdentifier { get; init; } = null!;
}