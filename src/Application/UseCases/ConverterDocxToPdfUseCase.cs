using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases;

public class ConverterDocxToPdfUseCase
{
    private readonly IDocxToPdfConverter _converter;

    public ConverterDocxToPdfUseCase(IDocxToPdfConverter converter)
    {
        _converter = converter;
    }

    public async Task<FileConversion> ConvertDocxToPdfAsync(Stream inputStream, string fileName)
    {
        var file = await _converter.ConvertAsync(inputStream, fileName);
        return file;
    }
}