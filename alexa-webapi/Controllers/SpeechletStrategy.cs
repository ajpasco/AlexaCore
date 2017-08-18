using System;
using System.IO;
using System.Text;
using AlexaCore.Speechlet.Request;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public class SpeechletStrategy
{
    public void ProcessSkillsRequest(HttpRequest request)
    {
        using (var br = new StreamReader(request.Body))
        {
            string json = br.ReadToEnd();
            var settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;

            var sRequest = JsonConvert.DeserializeObject<SpeechRequest>(json);

            Console.WriteLine(sRequest);
        }            
    }
}