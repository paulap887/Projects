using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SuitAlteration.Messaging.Receive.Dto;
using SuitAlteration.Messaging.Receive.Service.Interfaces;

namespace SuitAlteration.Messaging.Receive
{
    public class AlterationPaidReceiveFunction 
    {
        private readonly IAlterationService _service;
        public AlterationPaidReceiveFunction(IAlterationService service)
        {
            _service = service;
        }
        [FunctionName("AlterationPaidReceiveFunction")]
        public async Task Run([ServiceBusTrigger("%ServiceBusTopicName%", "%OrderPaidSubscriptionName%",
            Connection = "ServiceBusConnectionString")]string mySbMsg, ILogger _logger)
        {
            var requestModel = JsonConvert.DeserializeObject<OrderPaidMessageDto>(mySbMsg);

            if (requestModel != null)
            {
                await _service.UpdateAlterationAsPaid(requestModel.AlterationId).ConfigureAwait(false);
            }

            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
