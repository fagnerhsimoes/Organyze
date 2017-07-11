using Newtonsoft.Json;
using Organyze.Interfaces;

namespace Organyze.Models
{
    public class Departamento: BaseDataObject, IDepartamento
    {
        string nome;
        bool   apagado;

        [JsonProperty(PropertyName = "nome")]
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        [JsonProperty(PropertyName = "apagado")]
        public bool Apagado
        {
            get { return apagado; }
            set { apagado = value; }
        }
    }
}

