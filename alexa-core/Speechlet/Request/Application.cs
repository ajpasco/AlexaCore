using Newtonsoft.Json;

namespace AlexaCore.Speechlet.Request
{
    public class Application
    {
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set;}
    }
}