using System;
using Organyze.Helpers;
using Organyze.Interfaces;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace Organyze.Models
{
    public class BaseDataObject : ObservableObject, IBaseDataObject
    {
         public BaseDataObject()
         {
            //Id = Guid.NewGuid().ToString();
         }

         string id;

         [JsonProperty(PropertyName = "id")]
         public string Id
         {
             get { return id; }
             set { id = value; }
         }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public bool           Sinc      { get; set; }
        public bool           Apagado   { get; set; }

        [Version]
        public string         Version   { get; set; }
    }
}
