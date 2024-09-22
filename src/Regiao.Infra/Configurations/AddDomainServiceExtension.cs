using Microsoft.Extensions.DependencyInjection;
using Regiao.Domain.Contracts;
using Regiao.Infra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regiao.Infra.Configurations
{
    public static class AddDomainServiceExtension
    {
        public static void AddDomainService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBuscaRegiaoService, BuscaRegiaoService>();
        }
    }
}
