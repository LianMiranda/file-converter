using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases;

public class ConverterPdfToHtmlUseCase
{
    private readonly IPdfToHtmlConverter _converter;

    public ConverterPdfToHtmlUseCase(IPdfToHtmlConverter converter)
    {
        _converter = converter;
    }

    public async Task<FileConversion> ConverterPdfToHtmlAsync(Stream inputStream, string fileName)
    {
        var file = await _converter.ConvertAsync(inputStream, fileName);
        return file;
    }
}