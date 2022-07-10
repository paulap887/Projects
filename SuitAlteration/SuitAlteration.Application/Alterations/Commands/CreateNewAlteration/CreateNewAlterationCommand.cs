using MediatR;
using SuitAlteration.Application.Interfaces;
using SuitAlteration.Domain.Entities;
using SuitAlteration.Domain.Enums;
using SuitAlteration.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations.Commands;
public record CreateNewAlterationCommand : IRequest<int>
{
    public int CustomerId { get; set; } 
    public List<AlterationDetails> AlterationDetails { get; set; } 
    public int SalesAssociateId { get; set; }
    public string Remarks { get; set; }
}

public record AlterationDetails
{
    public SuitPieceType SuitPieceType { get; set; }  
    public SuitPieceTypeSide SuitPieceTypeSide { get; set; }  
    public decimal AdjustmentInCms { get; set; }   
}

