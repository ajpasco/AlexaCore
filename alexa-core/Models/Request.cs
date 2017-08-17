using Newtonsoft.Json;

namespace AlexaCore.Models
{
    public class Request
    {
        public RequestType Type { get; set;}

        [JsonProperty("requestId")]
        public string RequestId { get; set;}

        [JsonProperty("timestamp")]
        public string TimeStamp { get; set;}
    }
}