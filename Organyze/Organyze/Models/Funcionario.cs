using Newtonsoft.Json;

namespace Organyze.Models
{
    public class Funcionario : BaseDataObject
    {
        string nome         = string.Empty;
        [JsonProperty(PropertyName = "nome")]
        public string Nome
        {
            get { return nome; }
            set { SetProperty(ref nome, value); }
        }

        string cpf          = string.Empty;
        [JsonProperty(PropertyName = "cpf")]
        public string Cpf
        {
            get { return cpf; }
            set { SetProperty(ref cpf, value); }
        }

        string departamento = string.Empty;
        [JsonProperty(PropertyName = "departamento")]
        public string Departamento
        {
            get { return departamento; }
            set { SetProperty(ref departamento, value); }
        }

        string telefone     = string.Empty;
        [JsonProperty(PropertyName = "telefone")]
        public string Telefone
        {
            get { return telefone; }
            set { SetProperty(ref telefone, value); }
        }

        string celular      = string.Empty;
        [JsonProperty(PropertyName = "celular")]
        public string Celular
        {
            get { return celular; }
            set { SetProperty(ref celular, value); }
        }

        string email        = string.Empty;
        [JsonProperty(PropertyName = "email")]
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
    }
}
