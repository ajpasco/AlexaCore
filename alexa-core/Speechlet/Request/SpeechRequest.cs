using System;
using Newtonsoft.Json;

namespace AlexaCore.Speechlet.Request
{
    public class SpeechRequest
    {
        [JsonProperty("version")]
        public String Version { get; set; }

        public Context Context { get; set; }

        public Session Session { get; set;}
        
        public Request Request { get; set;}
    }
}