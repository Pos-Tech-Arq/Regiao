using Regiao.Domain.Command;
using Regiao.Domain.Contracts;
using RegiaoEntitie = Regiao.Domain.Entities;

namespace Regiao.Domain.Services;

public class CriaRegiaoService : ICriaRegiaoService
{
    private readonly IRegiaoRepository _regiaoRepository;
    private readonly IBuscaRegiaoService _buscaRegiaoService;

    public CriaRegiaoService(IRegiaoRepository regiaoRepository, IBuscaRegiaoService buscaRegiaoService)
    {
        _regiaoRepository = regiaoRepository;
        _buscaRegiaoService = buscaRegiaoService;
    }

    public async Task Handle(CriaRegiaoCommand command)
    {
        var regiao = new RegiaoEntitie.Regiao(command.Ddd);
        await regiao.AdicionaCidade(_regiaoRepository, _buscaRegiaoService);
        await _regiaoRepository.Create(regiao);
    }

}
