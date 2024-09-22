using Refit;
using Regiao.Infra.ExternalServices.BrasilApiService.Responses;

namespace Regiao.Infra.ExternalServices.BrasilApiService.BrasilApiService;

public interface IBrasilApi
{
    [Get("/api/ddd/v1/{ddd}")]
    Task<Region> BuscaRegiaoPorDdd(string ddd);
}