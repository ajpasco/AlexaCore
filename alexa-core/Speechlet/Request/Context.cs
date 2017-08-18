using Newtonsoft.Json;

namespace AlexaCore.Speechlet.Request
{
    public class Context
    {
        [JsonProperty("system")]
        public RequestSystem System { get; set;}
    }
}