using Domain.Interfaces;
using Infrastructure.Converters;
using Infrastructure.Converters.DocxFiles;
using Infrastructure.Converters.PdfFiles;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Config;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IPdfToDocxConverter, PdfToDocxConverter>();
        services.AddTransient<IDocxToPdfConverter, DocxToPdfConverter>();
        services.AddTransient<IPdfToHtmlConverter, PdfToHtmlConverter>();
        return services;
    }
}