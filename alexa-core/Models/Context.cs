using Newtonsoft.Json;

namespace AlexaCore.Models
{
    public class Context
    {
        [JsonProperty("system")]
        public RequestSystem System { get; set;}
    }
}