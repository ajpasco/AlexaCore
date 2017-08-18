using Newtonsoft.Json;

namespace AlexaCore.Speechlet.Response
{
    public class Image
    {
        [JsonProperty("smallImageUrl")]
        public string SmallImageUrl { get; set; }
        
        [JsonProperty("largeImageUrl")]
        public string LargeImageUrl { get; set; }
    }
}