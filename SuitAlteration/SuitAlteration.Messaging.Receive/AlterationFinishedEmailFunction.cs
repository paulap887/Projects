using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SuitAlteration.Messaging.Receive.Data.Dto;
using SuitAlteration.Messaging.Receive.Dto;
using SuitAlteration.Messaging.Receive.Service.Interfaces;

namespace SuitAlteration.Messaging.Receive
{
    public class AlterationFinishedEmailFunction
    {
        private readonly IAlterationService _service;
        public AlterationFinishedEmailFunction(IAlterationService service)
        {
            _service = service;
        }
        [FunctionName("AlterationFinishedEmailFunction")]
        public async Task Run([ServiceBusTrigger("%ServiceBusTopicName%", "%AlterationFinishedSubscriptionName%",
            Connection = "ServiceBusConnectionString")]string mySbMsg, ILogger _logger)
        {
            var requestModel = JsonConvert.DeserializeObject<AlterationFinishedDto>(mySbMsg);

            // Email Functionality goes here 

            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
