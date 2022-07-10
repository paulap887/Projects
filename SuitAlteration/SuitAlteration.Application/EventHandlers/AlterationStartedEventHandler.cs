using MediatR;
using Microsoft.Extensions.Logging;
using SuitAlteration.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.EventHandlers
{ 
    public class AlterationStartedEventHandler : INotificationHandler<AlterationStartedEvent>
    {
        private readonly ILogger<AlterationStartedEventHandler> _logger; 
         
        public AlterationStartedEventHandler(ILogger<AlterationStartedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(AlterationStartedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Alteration Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
