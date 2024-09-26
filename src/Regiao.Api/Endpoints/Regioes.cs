using Microsoft.AspNetCore.Mvc;
using Regiao.Domain.Command;
using Regiao.Domain.Contracts;

namespace Regiao.Api.Endpoints
{
    public static class Regioes
    {
        public static void RegisterContatosEndpoints(this IEndpointRouteBuilder routes)
        {
            var regiaoRoute = routes.MapGroup("/api/v1/regioes");

            regiaoRoute.MapPost("",
                async (ICriaRegiaoService criaContatoService, [FromQuery] string? ddd, string? numero) =>
        {
            var command = new CriaRegiaoCommand(ddd, numero);
            await criaContatoService.Handle(command);

            return TypedResults.NoContent();
        })
    .WithName("CriaContato")
    .WithOpenApi()
    .AddFluentValidationFilter();
        }
    }

}
