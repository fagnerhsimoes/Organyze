namespace Organyze.Interfaces
{
    public interface ICliente: IBaseDataObject
    {
        string NomeEmpresa  { get; set; }
        string Telefone     { get; set; }
        string Celular      { get; set; }
        string Cnpj         { get; set; }
        string Proprietario { get; set; }
        string Contato      { get; set; }
        string Email        { get; set; }
        bool   IsFavorite   { get; set; }
    }
}
