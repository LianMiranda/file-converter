using Aspose.Pdf;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Converters.PdfFiles;

public class PdfToDocxConverter : IPdfToDocxConverter
{
    public async Task<FileConversion> ConvertAsync(Stream inputStream, string fileName)
    {
        try
        {
            byte[] docxBytes;

            using (var ms = new MemoryStream())
            {
                using (var document = new Document(inputStream))
                {
                    document.Save(ms, SaveFormat.DocX);
                }

                docxBytes = ms.ToArray();
            }

            string outputFileName = Path.ChangeExtension(fileName, ".docx");

           var result = new FileConversion(
                outputFileName,
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                docxBytes
            );

            return await Task.FromResult(result);
        }
        catch (Exception e)
        {
            throw new InvalidOperationException(e.Message);
        }
    }
}