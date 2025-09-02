using Application.UseCases;
using Application.UseCases.DocxFilesUseCase;
using Application.UseCases.PdfFilesUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Config;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ConverterDocxToPdfUseCase>();
        services.AddScoped<ConverterPdfToDocxUseCase>();
        services.AddScoped<ConverterPdfToHtmlUseCase>();

        return services;
    }
}