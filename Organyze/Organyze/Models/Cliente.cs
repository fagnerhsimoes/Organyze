using Newtonsoft.Json;
using Organyze.Interfaces;

namespace Organyze.Models
{
    public class Cliente : BaseDataObject, ICliente
    {
        string nomeempresa  = string.Empty;
        string cnpj         = string.Empty;
        string proprietario = string.Empty;
        string contato      = string.Empty;
        string telefone     = string.Empty;
        string celular      = string.Empty;
        string email        = string.Empty;
        bool   isfavorite   = true;

        [JsonProperty(PropertyName = "nomeempresa")]
        public string NomeEmpresa
        {
            get { return nomeempresa; }
            set { SetProperty(ref nomeempresa, value); }
        }

        [JsonProperty(PropertyName = "cnpj")]
        public string Cnpj
        {
            get { return cnpj; }
            set { SetProperty(ref cnpj, value); }
        }

        [JsonProperty(PropertyName = "proprietario")]
        public string Proprietario
        {
            get { return proprietario; }
            set { SetProperty(ref proprietario, value); }
        }

        [JsonProperty(PropertyName = "contato")]
        public string Contato
        {
            get { return contato; }
            set { SetProperty(ref contato, value); }
        }

        [JsonProperty(PropertyName = "telefone")]
        public string Telefone
        {
            get { return telefone; }
            set { SetProperty(ref telefone, value); }
        }

        [JsonProperty(PropertyName = "celular")]
        public string Celular
        {
            get { return celular; }
            set { SetProperty(ref celular, value); }
        }

        [JsonProperty(PropertyName = "email")]
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        [JsonProperty(PropertyName = "isfavorite")]
        public bool IsFavorite
        {
            get { return isfavorite; }
            set { SetProperty(ref isfavorite, value); }
        }
    }
}
