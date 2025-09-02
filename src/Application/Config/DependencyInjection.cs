using Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Config;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ConverterDocxToPdfUseCase>();
        services.AddScoped<ConverterPdfToDocxUseCase>();

        return services;
    }
}