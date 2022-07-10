using MediatR;
using Microsoft.Extensions.Logging;
using SuitAlteration.Application.Messaging.Sender.AlterationFinished;
using SuitAlteration.Application.Messaging.Sender.OrderPaid;
using SuitAlteration.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.EventHandlers
{
    public class AlterationFinishedEventHandler : INotificationHandler<AlterationFinishedEvent>
    {
        private readonly ILogger<AlterationAddedEventHandler> _logger;
        private readonly IAlterationFinishedServiceBusSender _serviceBus;

        public AlterationFinishedEventHandler(ILogger<AlterationAddedEventHandler> logger,
            IAlterationFinishedServiceBusSender serviceBus)
        {
            _logger = logger;
            _serviceBus = serviceBus;
        }

        public Task Handle(AlterationFinishedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Alteration Domain Event: {DomainEvent}", notification.GetType().Name);

            _serviceBus.SendAlterationFinishedIToServiceBus(notification.Item.Id);

            return Task.CompletedTask;
        }
    }
}
