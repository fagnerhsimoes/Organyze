namespace Organyze.Interfaces
{
    public interface IOrdemServico : IBaseDataObject
    {
        string Numero         { get; set; }
        string Titulo         { get; set; }
        string Descricao      { get; set; }
        string Cliente        { get; set; }
        string Solicitante    { get; set; }
        string Projeto        { get; set; }
        string Funcionario    { get; set; }
        string Item           { get; set; }
        string Status         { get; set; }
        string ImgStat        { get; set; }
    }
}
