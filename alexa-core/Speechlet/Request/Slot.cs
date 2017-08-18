using Newtonsoft.Json;

namespace AlexaCore.Speechlet.Request
{
    public class Slot
    {
        [JsonProperty("name")]
        public string Name { get; set;}

        [JsonProperty("value")]
        public string Value { get; set;}

        [JsonProperty("confirmationStatus")]
        public string ConfirmationStatus { get; set;}
    }
}