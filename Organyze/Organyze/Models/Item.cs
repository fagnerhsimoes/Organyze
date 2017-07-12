using Newtonsoft.Json;

namespace Organyze.Models
{
    public class Item : BaseDataObject
    {
        string descricao = string.Empty;
        [JsonProperty(PropertyName = "descricao")]
        public string Descricao
        {
            get { return descricao; }
            set { SetProperty(ref descricao, value); }
        }

        string categoria = string.Empty;
        [JsonProperty(PropertyName = "categoria")]
        public string Categoria
        {
            get { return categoria; }
            set { SetProperty(ref categoria, value); }
        }
    }
}
