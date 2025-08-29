using Application.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.UseCases;

public class ConverterFileUseCase
{
    private readonly IFileConverter _converter;

    public ConverterFileUseCase(IFileConverter converter)
    {
        _converter = converter;
    }

    public async Task<FileConversion> ConvertToPdf(Stream inputStream, string fileName)
    {
        var file = await _converter.ConvertAsync(inputStream, fileName);
        return file;
    }
}