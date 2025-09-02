using Domain.Interfaces;
using Aspose.Words;
using Domain.Entities;

namespace Infrastructure.Converters;

public class DocxToPdfConverter : IDocxToPdfConverter
{
    public async Task<FileConversion> ConvertAsync(Stream inputStream, string fileName)
    {
        try
        {
            var document = new Document(inputStream);
            
            byte[] docxBytes;

            using (var ms = new MemoryStream())
            {
                document.Save(ms, SaveFormat.Pdf);
                docxBytes = ms.ToArray();
            }

            string outputFileName = Path.ChangeExtension(fileName, ".pdf");

            return new FileConversion(
                outputFileName,
                "application/pdf",
                docxBytes
            );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}