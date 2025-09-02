using Domain.Entities;

namespace Domain.Interfaces;

public interface IPdfToDocxConverter
{
    Task<FileConversion> ConvertAsync(Stream inputStream, string fileName);
}