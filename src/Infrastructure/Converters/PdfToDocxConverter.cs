using Application.Interfaces;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Domain.Entities;
using UglyToad.PdfPig;

namespace Infrastructure.Converters;

public class PdfToDocxConverter : IFileConverter
{
    public async Task<FileConversion> ConvertAsync(Stream inputStream, string fileName)
    {
        using var pdf = PdfDocument.Open(inputStream);
        
        byte[] docxBytes;
        
        using (var ms = new MemoryStream())
        {
            using (WordprocessingDocument doc =
                   WordprocessingDocument.Create(ms, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new Document();

                Body body = new Body();

                foreach (var page in pdf.GetPages())
                {
                    string txt = page.Text;
                    Paragraph paragraph = new Paragraph();
                    Run run = new Run();
                    Text text = new Text(txt);
                    
                    run.Append(text);
                    paragraph.Append(run);

                    body.Append(paragraph);
                }
                body.Append(new Paragraph());
                mainPart.Document.Append(body);
            }

            docxBytes = ms.ToArray();
        }

        return new FileConversion(
            fileName,
            "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            docxBytes
        );
    }
}