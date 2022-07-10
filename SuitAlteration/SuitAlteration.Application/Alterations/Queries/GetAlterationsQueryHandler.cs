using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SuitAlteration.Application.Common.Mappings;
using SuitAlteration.Application.Common.Models;
using SuitAlteration.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations.Queries
{ 
    public class GetAlterationsQueryHandler : IRequestHandler<GetAlterationsQuery, PaginatedList<AlterationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetAlterationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedList<AlterationDto>> Handle(GetAlterationsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Alterations.GetAlterationsByCustomerId(request.Status)        
                .ProjectTo<AlterationDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
