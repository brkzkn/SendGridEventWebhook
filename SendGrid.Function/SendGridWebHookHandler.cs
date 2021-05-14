using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SendGrid.Function
{
    public static class SendGridWebHookHandler
    {
        [FunctionName("sendgrid-webhook-handler")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var sendGridEvents = JsonConvert.DeserializeObject<List<SendGridEventsModel>>(requestBody);
            
            log.LogInformation($"Raw event: \r\n{requestBody}");
            foreach (var sendGridEvent in sendGridEvents)
            {
                // log individual event
                log.LogInformation(JsonConvert.SerializeObject(sendGridEvent));
            }

            return new OkObjectResult($"{sendGridEvents.Count} events logged successfully");
        }
    }
}

