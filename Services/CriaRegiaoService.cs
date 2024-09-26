using Regiao.AntiCorruptionLayer.BrasilApiService.Services;
using Regiao.Domain.Commands;
using Regiao.Domain.Contracts;
using Regiao.Domain.Entities;

namespace Regiao.Domain.Services;

public class CriaRegiaoService(IRegiaoRepository regiaoRepository, IBuscaRegiaoService buscaRegiaoService)
    : ICriaRegiaoService
{
    public async Task Handle(CriaRegiaoCommand command)
    {
        var regiaoBrasilService = await buscaRegiaoService.BuscaRegiao(command.Ddd);
        var regiao = new Entities.Regiao(command.Ddd, regiaoBrasilService.State, command.CorrelationId);
        regiao.AdicionaCidades(regiaoBrasilService.cities.Select(c => new Cidade(c)));

        await regiaoRepository.Create(regiao);
    }
}