namespace Organyze.Interfaces
{
    public interface IDepartamento : IBaseDataObject
    {
        string Nome    { get; set; }
        bool   Apagado { get; set; }
    }
}
