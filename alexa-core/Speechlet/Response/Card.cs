using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AlexaCore.Speechlet.Response
{
    public class Card
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CardType Type { get; set; } = CardType.Simple;

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Image Image { get; set; }
    }
}