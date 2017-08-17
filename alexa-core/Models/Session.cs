using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaCore.Models
{
    public class Session
    {
        [JsonProperty("new")]
        public bool New { get; set;}

        [JsonProperty("sessionId")]
        public string SessionId { get; set;}

        [JsonExtensionData]
        public Dictionary<string, object> Attributes { get; set;}
    }
}