namespace Organyze.Interfaces
{
    public interface IItem : IBaseDataObject
    {
        string Descricao    { get; set; }
        string Categoria    { get; set; }
    }
}
