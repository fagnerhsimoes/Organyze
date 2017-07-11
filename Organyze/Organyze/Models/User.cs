using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Organyze.Models
{
    public class User : BaseDataObject
    {
        [JsonProperty("userid")]
        public string UserId { get; set; }
    }
}
