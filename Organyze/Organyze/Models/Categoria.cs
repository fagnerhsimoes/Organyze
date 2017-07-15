namespace Organyze.Models
{
    public class Categoria : BaseDataObject
    {
        public int    Id           { get; set; }
        public string Nome         { get; set; }
        public string Apagado      { get; set; }
        public string Sincronizado { get; set; }
        public string Ativo        { get; set; }
    }

}


