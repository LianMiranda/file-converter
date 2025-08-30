namespace Domain.ValueObjects;

//Tenho planos para isso depois
public class FileFormat
{
    public  string Format { get; }

    private FileFormat(string format)
    {
        Format = format.ToLowerInvariant();
    }

    public static FileFormat ValidFormat(string format)
    {
        if (String.IsNullOrEmpty(format)) throw new ArgumentNullException(nameof(format));

        format = format.TrimStart('.').ToLowerInvariant();
        
        string[] allowedFormats = ["pdf", "docx"];

        if (!allowedFormats.Contains(format)) throw new NotSupportedException($"Format '{format}' is not supported.");

        return new FileFormat(format);
    }
}