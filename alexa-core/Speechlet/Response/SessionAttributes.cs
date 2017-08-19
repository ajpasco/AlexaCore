using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaCore.Speechlet.Response
{
    public class SessionAttributes
    {
        [JsonExtensionData]
        public Dictionary<string, object> Attributes { get; set; }
    }
}