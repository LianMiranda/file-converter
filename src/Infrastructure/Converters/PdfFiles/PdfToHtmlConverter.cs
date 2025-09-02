using Aspose.Pdf;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Converters.PdfFiles;

public class PdfToHtmlConverter : IPdfToHtmlConverter
{
    public async Task<FileConversion> ConvertAsync(Stream inputStream, string fileName)
    {
        try
        {
            byte[] content;

            var htmlSaveOptions = new HtmlSaveOptions
            {
                PartsEmbeddingMode = HtmlSaveOptions.PartsEmbeddingModes.EmbedAllIntoHtml,
                LettersPositioningMethod = HtmlSaveOptions.LettersPositioningMethods
                    .UseEmUnitsAndCompensationOfRoundingErrorsInCss,
                RasterImagesSavingMode = HtmlSaveOptions.RasterImagesSavingModes.AsEmbeddedPartsOfPngPageBackground,
                FontSavingMode = HtmlSaveOptions.FontSavingModes.AlwaysSaveAsWOFF
            };

            using (var ms = new MemoryStream())
            {
                using (var doc = new Document(inputStream))
                {
                    doc.Save(ms, htmlSaveOptions);
                }

                content = ms.ToArray();
            }

            string outputFileName = Path.ChangeExtension(fileName, ".html");

            var result = new FileConversion(
                outputFileName,
                "text/html",
                content);

            return await Task.FromResult(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}