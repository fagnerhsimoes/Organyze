using Newtonsoft.Json;
using Organyze.Interfaces;

namespace Organyze.Models
{
    public class User : BaseDataObject, IUser
    {
        [JsonProperty("userid")]
        public string UserId { get; set; }
    }
}
