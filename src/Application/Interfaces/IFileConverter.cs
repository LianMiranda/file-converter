using Domain.Entities;

namespace Application.Interfaces;

public interface IFileConverter
{
    Task<FileConversion> ConvertAsync(Stream inputStream, string fileName);
}