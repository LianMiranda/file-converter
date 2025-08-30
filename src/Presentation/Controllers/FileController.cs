using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace conversor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    public ConverterFileUseCase _useCase;

    public FileController(ConverterFileUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("PdfToDocx")]
    public async Task<ActionResult> ConvertPdfToDocx(IFormFile file)
    {
        try
        {
            if (file.Length == 0) return BadRequest("Nenhum arquivo enviado.");

            var stream = file.OpenReadStream();
            var result = await _useCase.ConvertToPdf(stream, file.FileName);

            return File(result.Content, result.ContentType, result.FileName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}