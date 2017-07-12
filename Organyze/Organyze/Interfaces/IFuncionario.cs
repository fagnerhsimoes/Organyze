namespace Organyze.Interfaces
{
    public interface IFuncionario : IBaseDataObject
    {
        string Nome         { get; set; }
        string Cpf          { get; set; }
        string Departamento { get; set; }
        string Telefone     { get; set; }
        string Celular      { get; set; }
        string Email        { get; set; }
    }
}
