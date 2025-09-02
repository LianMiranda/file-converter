using Domain.Interfaces;
using Infrastructure.Converters;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Config;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IPdfToDocxConverter, PdfToDocxConverter>();
        services.AddTransient<IDocxToPdfConverter, DocxToPdfConverter>();
        return services;
    }
}