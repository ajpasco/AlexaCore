using Newtonsoft.Json;

namespace AlexaCore.Speechlet.Request
{
    public class Request
    {
        public RequestType Type { get; set;}

        [JsonProperty("requestId")]
        public string RequestId { get; set;}

        [JsonProperty("timestamp")]
        public string TimeStamp { get; set;}

        [JsonProperty("locale")]
        public string Locale { get; set;}

        public Intent Intent { get; set;}
    }
}