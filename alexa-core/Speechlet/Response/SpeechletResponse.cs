using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaCore.Speechlet.Response
{
    public class SpeechletResponse
    {
        [JsonProperty("version")]
        public string Version { get; set;} = "1.0";

        public SessionAttributes SessionAttributes { get; set; }

        [JsonProperty("response")]
        public Response Response { get; set;} = new Response();
    }
}