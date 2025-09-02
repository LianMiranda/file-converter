using Aspose.Words;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Converters.DocxFiles;

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

            var result = new FileConversion(
                outputFileName,
                "application/pdf",
                docxBytes
            );

            return await Task.FromResult(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}