using Application.Interfaces;
using Aspose.Pdf;
using Domain.Entities;

namespace Infrastructure.Converters;

public class PdfToDocxConverter : IFileConverter
{
    public async Task<FileConversion> ConvertAsync(Stream inputStream, string fileName)
    {
        try
        {
            byte[] docxBytes;

            using (var ms = new MemoryStream())
            {
                using (var document = new Aspose.Pdf.Document(inputStream))
                {
                    document.Save(ms, SaveFormat.DocX);
                }

                docxBytes = ms.ToArray();
            }

            string outputFileName = Path.ChangeExtension(fileName, ".docx");

            return new FileConversion(
                outputFileName,
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                docxBytes
            );
        }
        catch (Exception e)
        {
            throw new InvalidOperationException(e.Message);
        }
    }
}