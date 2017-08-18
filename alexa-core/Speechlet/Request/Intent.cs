using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaCore.Speechlet.Request
{
    public class Intent
    {
        [JsonProperty("name")]
        public string Name { get; set;}

        [JsonProperty("confirmationStatus")]
        public string ConfirmationStatus { get; set;}

        public Dictionary<string, Slot> Slots { get; set;}
    }
}