using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AlexaCore.Speechlet.Response
{
    public class OutputSpeech
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OutputSpeechType Type { get; set; } = OutputSpeechType.PlainText;

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("ssml", NullValueHandling = NullValueHandling.Ignore)]
        public string SSML { get; set; }
    }
}