using Microsoft.Extensions.DependencyInjection;
using Regiao.AntiCorruption.BrasilApiService.Services;

namespace Regiao.Infra.Configurations;

public static class AddDomainServiceExtension
{
    public static void AddDomainService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBuscaRegiaoService, BuscaRegiaoService>();
    }
}