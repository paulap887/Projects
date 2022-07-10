using MediatR;
using SuitAlteration.Application.Common.Models;
using SuitAlteration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations.Queries;

public record GetAlterationsQuery : IRequest<PaginatedList<AlterationDto>>
{
    public AlterationStatus Status { get; init; }   
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

