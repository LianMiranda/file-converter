using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases;

public class ConverterPdfToDocxUseCase
{
    private readonly IPdfToDocxConverter _converter;

    public ConverterPdfToDocxUseCase(IPdfToDocxConverter converter)
    {
        _converter = converter;
    }
    
    public async Task<FileConversion> ConvertPdfToDocxAsync(Stream inputStream, string fileName)
    {
        var file = await _converter.ConvertAsync(inputStream, fileName);
        return file;
    }
}