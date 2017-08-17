using Newtonsoft.Json;

namespace AlexaCore.Models
{
    public class Application
    {
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set;}
    }
}