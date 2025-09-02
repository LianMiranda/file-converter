using Domain.Entities;

namespace Domain.Interfaces;

public interface IPdfToHtmlConverter
{
    Task<FileConversion> ConvertAsync(Stream inputStream, string fileName);
}