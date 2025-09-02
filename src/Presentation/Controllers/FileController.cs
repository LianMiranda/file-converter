using Application.UseCases;
using Application.UseCases.DocxFilesUseCase;
using Application.UseCases.PdfFilesUseCase;
using Microsoft.AspNetCore.Mvc;

namespace conversor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly ConverterPdfToDocxUseCase _converterPdfToDocxUseCase;
    private readonly ConverterDocxToPdfUseCase _converterDocxToPdfUseCase;
    private readonly ConverterPdfToHtmlUseCase _converterPdfToHtmlUseCase;

    public FileController(ConverterPdfToDocxUseCase converterPdfToDocxUseCase,
        ConverterDocxToPdfUseCase converterDocxToPdfUseCase, ConverterPdfToHtmlUseCase converterPdfToHtmlUseCase)
    {
        _converterPdfToDocxUseCase = converterPdfToDocxUseCase;
        _converterDocxToPdfUseCase = converterDocxToPdfUseCase;
        _converterPdfToHtmlUseCase = converterPdfToHtmlUseCase;
    }

    [HttpPost("PdfToDocx")]
    public async Task<ActionResult> ConvertPdfToDocx(IFormFile file)
    {
        try
        {
            if (file.Length == 0) return BadRequest("Nenhum arquivo enviado.");

            var stream = file.OpenReadStream();
            var result = await _converterPdfToDocxUseCase.ConvertPdfToDocxAsync(stream, file.FileName);

            return File(result.Content, result.ContentType, result.FileName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost("DocxToPdf")]
    public async Task<ActionResult> ConvertDocxToPdf(IFormFile file)
    {
        try
        {
            if (file.Length == 0) return BadRequest("Nenhum arquivo enviado.");

            var stream = file.OpenReadStream();
            var result = await _converterDocxToPdfUseCase.ConvertDocxToPdfAsync(stream, file.FileName);

            return File(result.Content, result.ContentType, result.FileName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost("PdfToHtml")]
    public async Task<ActionResult> ConverterPdfToHtml(IFormFile file)
    {
        try
        {
            if (file.Length == 0) return BadRequest("Nenhum arquivo enviado.");

            var stream = file.OpenReadStream();
            var result = await _converterPdfToHtmlUseCase.ConverterPdfToHtmlAsync(stream, file.FileName);

            return File(result.Content, result.ContentType, result.FileName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}