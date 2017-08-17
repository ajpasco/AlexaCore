using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace alexa_webapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // POST api/values
        [HttpPost]
        public void PostAsync()
        {
            var request = this.Request;
            var strategy = new SpeechletStrategy();
            strategy.ProcessSkillsRequest(request);
            /* 
            using (var br = new StreamReader(request.Body))
            {
                string body = br.ReadToEnd();

                var strategy = new SpeechletStrategy();
                strategy.ProcessSkillsRequest()
                //request.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));

                //Console.WriteLine(body);
                //System.Diagnostics.Debug.Print(body);
            }
            */
        }

       
    }
}
