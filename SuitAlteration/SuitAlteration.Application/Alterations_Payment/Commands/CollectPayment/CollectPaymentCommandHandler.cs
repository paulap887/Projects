using MediatR;
using SuitAlteration.Application.Common.Exceptions;
using SuitAlteration.Application.Interfaces;
using SuitAlteration.Application.Messaging.Sender.OrderPaid;
using SuitAlteration.Domain.Entities;
using SuitAlteration.Domain.Enums;
using SuitAlteration.Domain.Events;
using SuitAlteration.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations_Payment.Commands.CollectPayment
{
    public class CollectPaymentCommandHandler : IRequestHandler<CollectPaymentCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollectPaymentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CollectPaymentCommand request, CancellationToken cancellationToken)
        {
            if (request.EntityType != Domain.Enums.PaymentCollectionEntityType.Alterations)
            {
                throw new NotValidEntityForPaymentException();
            }

            // Fetch by Entity Id
            var entity = await _unitOfWork.Alterations.SingleOrDefaultAsync(a => a.Id == request.EntityId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Alteration), request.EntityId);
            }

            // Stop if the Alteration is not newly created  
            if (entity.Status != AlterationStatus.Created)
            {
                throw new NotValidEntityForPaymentException();
            }

            // Throw Event and Save Changes 
            entity.Status = AlterationStatus.Paid;
            entity.Amount = request.Amount;

            entity.AddDomainEvent(new AlterationPaidEvent(entity));

            await _unitOfWork.CommitAsync(cancellationToken);

            return entity.Id;
        }
    }
}
