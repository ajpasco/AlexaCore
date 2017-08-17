using System.IO;
using System.Text;
using AlexaCore.Models;
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
            //request.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));

            //Console.WriteLine(body);
            //System.Diagnostics.Debug.Print(body);
        }            
    }
}