using Regiao.AntiCorruption.BrasilApiService;
using Regiao.Domain.Contracts;
using RegiaoEntities = Regiao.Domain.Entities;

namespace Regiao.Infra.Services;

public class BuscaRegiaoService : IBuscaRegiaoService
{
    private readonly IBrasilApi _brasilApi;

    public BuscaRegiaoService(IBrasilApi brasilApi)
    {
        _brasilApi = brasilApi;
    }

    public async Task<RegiaoEntities.Regiao> BuscaRegiao(string ddd)
    {
        var region = await _brasilApi.BuscaRegiaoPorDdd(ddd);

        var cidades = region.cities.Select(c => new RegiaoEntities.Cidade(c)).ToList();

        return new RegiaoEntities.Regiao(ddd, cidades, region.State);
    }
}