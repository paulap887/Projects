using MediatR;
using Microsoft.Extensions.Logging;
using SuitAlteration.Application.Messaging.Sender.OrderPaid;
using SuitAlteration.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.EventHandlers
{
    public class AlterationPaidEventHandler : INotificationHandler<AlterationPaidEvent>
    {
        private readonly ILogger<AlterationPaidEventHandler> _logger;
        private readonly IAlterationPaidServiceBusSender _serviceBus;

        public AlterationPaidEventHandler(ILogger<AlterationPaidEventHandler> logger,
            IAlterationPaidServiceBusSender serviceBus)
        {
            _logger = logger;
            _serviceBus = serviceBus;

        }

        public async Task Handle(AlterationPaidEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Alteration Domain Event: {DomainEvent}", notification.GetType().Name);

            await _serviceBus.SendAlterationPaidIToServiceBus(notification.Item.Id); 
        }
    }
}
