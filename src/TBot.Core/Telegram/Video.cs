namespace TBot.Core.Telegram;

public class Video
{
    public string FileId { get; private set; }
    public string FileUniqueId { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int Duration { get; private set; }
    public PhotoSize? Thumbnail { get; private set; }
    public string? FileName { get; private set; }
    public string? MimeType { get; private set; }
    public int? FileSize { get; private set; }

    public Video(
        string fileId, 
        string fileUniqueId, 
        int width,
        int height,
        int duration, 
        PhotoSize? thumbnail,
        string? fileName,
        string? mimeType,
        int? fileSize)
    {
        FileId = fileId;
        FileUniqueId = fileUniqueId;
        Width = width;
        Height = height;
        Duration = duration;
        Thumbnail = thumbnail;
        FileName = fileName;
        MimeType = mimeType;
        FileSize = fileSize;
    }
}