namespace Organyze.Interfaces
{
    public interface ITodoItem : IBaseDataObject
    {
        string Name    { get; set; }
        bool   Done    { get; set; }
    }
}
