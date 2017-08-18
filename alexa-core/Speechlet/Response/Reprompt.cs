using Newtonsoft.Json;

namespace AlexaCore.Speechlet.Response
{
    public class Reprompt
    {
        [JsonProperty("outputSpeech")]
        public OutputSpeech OutputSpeech { get; set; }
    }
}