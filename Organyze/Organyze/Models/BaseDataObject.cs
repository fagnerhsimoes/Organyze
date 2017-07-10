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


        string         id;
        //DateTimeOffset createdAt;
        //DateTimeOffset updatedAt;
        //string         version;

         [JsonProperty(PropertyName = "id")]
         public string Id
         {
             get { return id; }
             set { id = value; }
         }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        [Version]
        public string Version { get; set; }
    }
}
