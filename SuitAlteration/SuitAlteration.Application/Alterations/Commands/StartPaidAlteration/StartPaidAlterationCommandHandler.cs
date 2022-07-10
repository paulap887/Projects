using MediatR;
using SuitAlteration.Application.Common.Exceptions;
using SuitAlteration.Application.Interfaces;
using SuitAlteration.Domain.Entities;
using SuitAlteration.Domain.Enums;
using SuitAlteration.Domain.Events;
using SuitAlteration.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations.Commands.StartPaidAlteration
{
    public class StartPaidAlterationCommandHandler : IRequestHandler<StartPaidAlterationCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public StartPaidAlterationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(StartPaidAlterationCommand request, CancellationToken cancellationToken)
        {
            // Fetch by Entity Id
            var entity = await _unitOfWork.Alterations.SingleOrDefaultAsync(a => a.Id == request.AlterationId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Alteration), request.AlterationId);
            }

            // Stop if the Alteration is not paid 
            if (entity.Status != AlterationStatus.Paid)
            {
                throw new CantStartUnpaidAlterationException();
            }

            // Throw Event and Save Changes 
            entity.Status = AlterationStatus.Started;

            entity.AddDomainEvent(new AlterationStartedEvent(entity));

            await _unitOfWork.CommitAsync(cancellationToken);

            return entity.Id;
        }
    }
}
