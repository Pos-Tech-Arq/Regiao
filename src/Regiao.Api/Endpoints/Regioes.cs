using Microsoft.AspNetCore.Mvc;
using Regiao.Domain.Contracts;

namespace Regiao.Api.Endpoints
{
    public static class Regioes
    {
        public static void RegisterContatosEndpoints(this IEndpointRouteBuilder routes)
        {
            var regiaoRoute = routes.MapGroup("/api/v1/regioes");

            regiaoRoute.MapGet("", async (IRegiaoRepository regiaoRepository, [FromQuery] string? ddd) =>
             {
                 var contatos = await regiaoRepository.GetByDdd(ddd);

                 return TypedResults.Ok(contatos);
             })
               .WithName("BuscaRegioes")
               .WithOpenApi()
               .AddFluentValidationFilter();
        }
    }

}
