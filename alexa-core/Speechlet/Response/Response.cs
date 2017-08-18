using Newtonsoft.Json;

namespace AlexaCore.Speechlet.Response
{
    public class Response
    {
        [JsonProperty("outputSpeech", NullValueHandling = NullValueHandling.Ignore)]
        public OutputSpeech OutputSpeech { get; set; }

        [JsonProperty("card", NullValueHandling = NullValueHandling.Ignore)]
        public Card Card { get; set; }

        [JsonProperty("reprompt", NullValueHandling = NullValueHandling.Ignore)]
        public Reprompt Reprompt { get; set; }

        [JsonProperty("shouldEndSession")]
        public bool ShouldEndSession { get; set;} = true;
    }
}