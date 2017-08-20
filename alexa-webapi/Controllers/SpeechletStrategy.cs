using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AlexaCore.Speechlet.Request;
using AlexaCore.Speechlet.Response;
using Macro.Models;
using Macro.Services;
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
                response.SessionAttributes = new SessionAttributes();
                response.SessionAttributes.Attributes = new Dictionary<string, object>();

                switch (req.Intent.Name)
                {
                    case "HowManyCaloriesIntent":
                        response = GenerateSpeechletResponse("To calculate your maintenance calories, I will be asking you a set of questions.  How old are you?", null);
                        break;
                    case "MyAgeIntent":
                        response.SessionAttributes.Attributes.Add("age", speechRequest.Request.Intent.Slots["age"].Value);
                        response = GenerateSpeechletResponse("Are you a male?  Please answer yes or no.", response.SessionAttributes);
                        break;
                    case "MyGenderIntent":  
                        response.SessionAttributes.Attributes = speechRequest.Session.CloneAttributes();

                        bool isMale = false;
                        if (speechRequest.Request.Intent.Slots["gender"].Value.ToUpper() == "YES")
                        {
                            isMale = true;
                        }

                        response.SessionAttributes.Attributes.Add("isMale", isMale);
                        response = GenerateSpeechletResponse("What is your height in feet and inches? Please answer in the following format.  I am five feet, nine inches.", response.SessionAttributes);
                        break;
                    case "MyHeightIntent":  
                        response.SessionAttributes.Attributes = speechRequest.Session.CloneAttributes();
                        response.SessionAttributes.Attributes.Add("height", speechRequest.Request.Intent.Slots["height"].Value);
                        response.SessionAttributes.Attributes.Add("inches", speechRequest.Request.Intent.Slots["inches"].Value);
                        response = GenerateSpeechletResponse("What is your weight in pounds?  Please answer in the following format.  I am one hundred and fifty pounds", response.SessionAttributes);
                        break;
                    case "MyWeightIntent":  
                        response.SessionAttributes.Attributes = speechRequest.Session.CloneAttributes();
                        
                        var reqSlots = speechRequest.Request.Intent.Slots;
                        var person = new Person()
                        {
                            Age = int.Parse(reqSlots["age"].Value),
                            HeightFeet = int.Parse(reqSlots["height"].Value),
                            HeightInches = int.Parse(reqSlots["inches"].Value),
                            WeightPounds = double.Parse(reqSlots["weight"].Value),
                        };

                        person.Gender = bool.Parse(reqSlots["isMale"].Value) ? Gender.Male : Gender.Female;

                        var calorieService = new CalorieService();
                        var calories = calorieService.CalcuateRestingEnergyExpenditure(person);

                        response = GenerateSpeechletResponse("The number of maintenance calories that you can consume is " + calories);
                        break;
                }
               
            }
        }            

        return response;
    }


    private SpeechletResponse GenerateSpeechletResponse(string text, SessionAttributes sessionData = null)
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