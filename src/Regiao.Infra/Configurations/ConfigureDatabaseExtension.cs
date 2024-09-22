using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Regiao.Infra.Contexts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Regiao.Infra.Configurations;

public static class ConfigureDatabaseExtension
{
    public static void ConfigureDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
    {

//     serviceCollection.AddDbContext<ApplicationDbContext>(options =>
// options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
// 
   
    serviceCollection.AddDbContext<ApplicationDbContext>(
        options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("Regiao.Infra")
        ));
    }
}



