namespace TBot.Core.Parameters.InputFileParameters;

public class VideoFile : InputFile
{
    public override string ContentMediaType => "multipart/form-data";
    protected internal override object Value => Stream;
    public Stream Stream { get; init; } = null!;
}