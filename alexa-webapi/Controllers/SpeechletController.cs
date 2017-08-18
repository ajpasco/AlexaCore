using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using AlexaCore.Speechlet.Response;

namespace alexa_webapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // POST api/values
        [HttpPost]
        public SpeechletResponse PostAsync()
        {
            var request = this.Request;
            var strategy = new SpeechletStrategy();
            strategy.ProcessSkillsRequest(request);


            var response = new SpeechletResponse();

            response.Response.OutputSpeech = new OutputSpeech(){
                 Text = "hello world",
                 Type = OutputSpeechType.PlainText
            };

            response.Response.Card = new Card(){
                Type = CardType.Simple,
                Title = "Horoscope",
                Content = "Hello world"
            };

            response.Response.Reprompt = new Reprompt(){
                OutputSpeech = new OutputSpeech(){
                    Type = OutputSpeechType.PlainText,
                    Text = "Can I help you?"
                }
            };

            return response;
        }

       
    }
}
