﻿using Newtonsoft.Json;
using Organyze.Interfaces;

namespace Organyze.Models
{
    public class Departamento: BaseDataObject, IDepartamento
    {
        string nome = string.Empty;

        [JsonProperty(PropertyName = "nome")]
        public string Nome
        {
            get { return nome; }
            set { SetProperty(ref nome, value); }
        }
    }
}

