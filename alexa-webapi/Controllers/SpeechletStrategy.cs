using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AlexaCore.Speechlet.Request;
using AlexaCore.Speechlet.Response;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public class SpeechletStrategy
{
    public SpeechletResponse ProcessSkillsRequest(HttpRequest request)
    {
        var response = new SpeechletResponse();

        using (var br = new StreamReader(request.Body))
        {
            string json = br.ReadToEnd();
            var settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;

            var speechRequest = JsonConvert.DeserializeObject<SpeechRequest>(json);

            var req = speechRequest.Request;
            
            if (req.Type == RequestType.IntentRequest)
            {
                if (req.Intent.Name == "HowManyCaloriesIntent")
                {
                    response = GenerateSpeechletResponse("What is your age?", null);
                }

                if (req.Intent.Name == "MyAgeIntent")
                {
                    response.SessionAttributes = new SessionAttributes();
                    response.SessionAttributes.Attributes = new Dictionary<string, object>();
                    response.SessionAttributes.Attributes.Add("age", speechRequest.Request.Intent.Slots["age"].Value);
                    response = GenerateSpeechletResponse("What is your gender?", response.SessionAttributes);
                }
            }
            //Console.WriteLine(sRequest);
        }            

        return response;
    }


    private SpeechletResponse GenerateSpeechletResponse(string text, SessionAttributes sessionData)
    {
          var response = new SpeechletResponse();

            response.Response.OutputSpeech = new OutputSpeech(){
                 Text = text,
                 Type = OutputSpeechType.PlainText
            };

            response.SessionAttributes = sessionData;
            response.Response.ShouldEndSession = false;

            return response;
    }
}