namespace Regiao.Domain.Command;

public class CriaRegiaoCommand(string ddd, string numero)
{
    public string Ddd => ddd;
    public string Numero => numero;
}
