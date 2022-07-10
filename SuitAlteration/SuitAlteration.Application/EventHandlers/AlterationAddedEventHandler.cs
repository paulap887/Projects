using MediatR;
using Microsoft.Extensions.Logging;
using SuitAlteration.Domain.Events;

namespace SuitAlteration.Application.EventHandlers
{
    public class AlterationAddedEventHandler : INotificationHandler<AlterationAddedEvent>
    {
        private readonly ILogger<AlterationAddedEventHandler> _logger;

        public AlterationAddedEventHandler(ILogger<AlterationAddedEventHandler> logger) 
        {
            _logger = logger;
        }

        public Task Handle(AlterationAddedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Alteration Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
