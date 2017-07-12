using Newtonsoft.Json;
using Organyze.Interfaces;

namespace Organyze.Models
{
    public class OrdemServico : BaseDataObject, IOrdemServico
    {
        string numero      = string.Empty;
        [JsonProperty(PropertyName = "numero")]
        public string Numero
        {
            get { return numero; }
            set { SetProperty(ref numero, value); }
        }

        string titulo      = string.Empty;
        [JsonProperty(PropertyName = "titulo")]
        public string Titulo
        {
            get { return titulo; }
            set { SetProperty(ref titulo, value); }
        }


        string descricao   = string.Empty;
        [JsonProperty(PropertyName = "descricao")]
        public string Descricao
        {
            get { return descricao; }
            set { SetProperty(ref descricao, value); }
        }


        string cliente     = string.Empty;
        [JsonProperty(PropertyName = "cliente")]
        public string Cliente
        {
            get { return cliente; }
            set { SetProperty(ref cliente, value); }
        }


        string solicitante = string.Empty;
        [JsonProperty(PropertyName = "solicitante")]
        public string Solicitante
        {
            get { return solicitante; }
            set { SetProperty(ref solicitante, value); }
        }


        string projeto     = string.Empty;
        [JsonProperty(PropertyName = "projeto")]
        public string Projeto
        {
            get { return projeto; }
            set { SetProperty(ref projeto, value); }
        }


        string funcionario = string.Empty;
        [JsonProperty(PropertyName = "funcionario")]
        public string Funcionario
        {
            get { return funcionario; }
            set { SetProperty(ref funcionario, value); }
        }


        string item        = string.Empty;
        [JsonProperty(PropertyName = "item")]
        public string Item
        {
            get { return item; }
            set { SetProperty(ref item, value); }
        }


        string status      = string.Empty;
        [JsonProperty(PropertyName = "status")]
        public string Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }


        string imgstat     = string.Empty;
        [JsonProperty(PropertyName = "imgstat")]
        public string ImgStat
        {
            get
            {
                if (Status == "C")
                {
                    return "ok2.png";
                }
                else if(Status == "E")
                {
                    return "play.png";
                }
                else if (Status == "P")
                {
                    return "ampulheta.png";
                }
                else
                {
                    return "erro2.png";
                }
            }
            set { SetProperty(ref imgstat, value); }
        }
    }
}
