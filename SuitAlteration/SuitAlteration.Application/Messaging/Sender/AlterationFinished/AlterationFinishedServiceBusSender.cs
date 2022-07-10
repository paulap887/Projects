using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SuitAlteration.Application.Messaging.Configuration;
using SuitAlteration.Application.Messaging.Sender.OrderPaid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Messaging.Sender.AlterationFinished
{
    public class AlterationFinishedServiceBusSender : IAlterationFinishedServiceBusSender
    {
        private readonly ILogger _logger;
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _clientSender;

        public AlterationFinishedServiceBusSender(IOptions<AzureServiceBusConfiguration> serviceBusOptions,
            ILogger<AlterationFinishedServiceBusSender> logger)
        {
            _client = new ServiceBusClient(serviceBusOptions.Value.ConnectionString);
            _clientSender = _client.CreateSender(serviceBusOptions.Value.OrderPaidTopicName);
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task SendAlterationFinishedIToServiceBus(int alterationId)
        {
            var payload = new AlterationPaidDto()
            {
                AlterationId = alterationId
            };

            string messagePayload = JsonConvert.SerializeObject(payload);
            ServiceBusMessage message = new ServiceBusMessage(messagePayload);

            try
            {
                await _clientSender.SendMessageAsync(message).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            } 
        }
    }
}
