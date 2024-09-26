using Regiao.Domain.Contracts;

namespace Regiao.Domain.Entities;

public class Regiao : Entidade, IAggregateRoot
{
    public string Ddd { get; private set; }

    public ICollection<Cidade> Cidades { get; private set; }
    public string Estado { get; private set; }

    public Regiao(string ddd)
    {
        Ddd = ddd;
        Id = Guid.NewGuid();
    }
    public Regiao(string ddd, ICollection<Cidade> cidades, string estado)
    {
        Ddd = ddd;
        Id = Guid.NewGuid();
        Cidades = cidades;
        Estado = estado;
    }

    public async Task AdicionaCidade(IRegiaoRepository regiaoRepository, IBuscaRegiaoService buscaRegiaoService)
    {
        var regiao = await regiaoRepository.GetByDdd(this.Ddd) ?? await buscaRegiaoService.BuscaRegiao(this.Ddd);

        this.Estado = regiao.Estado;
        this.Cidades = regiao.Cidades;
    }

    private Regiao()
    {
    }
}
