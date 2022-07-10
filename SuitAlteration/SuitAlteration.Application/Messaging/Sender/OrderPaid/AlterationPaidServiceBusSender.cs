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

namespace SuitAlteration.Application.Messaging.Sender
{
    public class AlterationPaidServiceBusSender : IAlterationPaidServiceBusSender
    {
        private readonly ILogger _logger;
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _clientSender;

        public AlterationPaidServiceBusSender(IOptions<AzureServiceBusConfiguration> serviceBusOptions,
            ILogger<AlterationPaidServiceBusSender> logger)
        { 
            _client = new ServiceBusClient(serviceBusOptions.Value.ConnectionString);
            _clientSender = _client.CreateSender(serviceBusOptions.Value.OrderPaidTopicName);
            _logger = logger;
        }

        public async Task SendAlterationPaidIToServiceBus(int alterationId)
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
