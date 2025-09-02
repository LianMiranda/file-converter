using Domain.Entities;

namespace Domain.Interfaces;

public interface IDocxToPdfConverter
{
    Task<FileConversion> ConvertAsync(Stream inputStream, string fileName);
}