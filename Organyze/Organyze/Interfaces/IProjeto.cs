namespace Organyze.Interfaces
{
    public interface IProjeto : IBaseDataObject
    {
        string Nome         { get; set; }
        string Descricao    { get; set; }
        string Categoria    { get; set; }
        string Sincronizado { get; set; }
        bool   Ativo        { get; set; }
    }
}
