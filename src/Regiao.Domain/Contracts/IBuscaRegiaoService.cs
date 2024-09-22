using RegionEntitie = Regiao.Domain.Entities;

namespace Regiao.Domain.Contracts;

public interface IBuscaRegiaoService
{
    Task<RegionEntitie.Regiao> BuscaRegiao(string ddd);
}