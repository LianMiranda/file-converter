using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace conversor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly ConverterPdfToDocxUseCase _converterPdfToDocxUseCase;
    private readonly ConverterDocxToPdfUseCase _converterDocxToPdfUseCase;

    public FileController(ConverterPdfToDocxUseCase converterPdfToDocxUseCase, ConverterDocxToPdfUseCase converterDocxToPdfUseCase)
    {
        _converterPdfToDocxUseCase = converterPdfToDocxUseCase;
        _converterDocxToPdfUseCase = converterDocxToPdfUseCase;
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
}