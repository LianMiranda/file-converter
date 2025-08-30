namespace Domain.Entities;

public class FileConversion
{
    public string FileName { get; }
    public string ContentType { get; }
    public byte[] Content { get; }

    public FileConversion(string fileName, string contentType, byte[] content)
    {
        FileName = fileName;
        ContentType = contentType;
        Content = content;
    }
}