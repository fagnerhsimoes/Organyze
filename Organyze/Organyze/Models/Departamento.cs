using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace Organyze.Models
{
    public class Departamento
    {

        private string id      { get; set; } = Guid.NewGuid().ToString();
        private string nome    { get; set; }
        private bool   apagado { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

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

        [Version]
        public string Version { get; set; }
    }
}

