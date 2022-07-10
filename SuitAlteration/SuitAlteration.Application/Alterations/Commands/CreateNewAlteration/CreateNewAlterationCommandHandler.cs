using MediatR;
using SuitAlteration.Application.Interfaces;
using SuitAlteration.Domain.Entities;
using SuitAlteration.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations.Commands.CreateNewAlteration 
{
    public class CreateNewAlterationCommandHandler : IRequestHandler<CreateNewAlterationCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateNewAlterationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateNewAlterationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Alteration
            {
                CustomerId = request.CustomerId,
                SalesAssociateId = request.SalesAssociateId,
                Status = Domain.Enums.AlterationStatus.Created,
                Remarks = request.Remarks,
                PieceTypeDetails =  request.AlterationDetails
                                .Select(x=> new AlterationPieceTypeDetail()
                                {
                                    AdjustmentInCms = x.AdjustmentInCms,
                                    SuitPieceTypeSide = x.SuitPieceTypeSide, 
                                }).ToList()
            };

            entity.AddDomainEvent(new AlterationAddedEvent(entity));

            await _unitOfWork.Alterations.AddAsync(entity);

            await _unitOfWork.CommitAsync(cancellationToken);

            return entity.Id;
        }
    }
}
