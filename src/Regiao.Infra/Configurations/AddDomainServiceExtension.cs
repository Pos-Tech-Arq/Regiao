using Microsoft.Extensions.DependencyInjection;
using Regiao.Domain.Contracts;
using Regiao.Domain.Services;
using Regiao.Infra.Services;

namespace Regiao.Infra.Configurations;

public static class AddDomainServiceExtension
{
    public static void AddDomainService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBuscaRegiaoService, BuscaRegiaoService>();
        serviceCollection.AddScoped<ICriaRegiaoService, CriaRegiaoService>();
    }
}