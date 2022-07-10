using MediatR;
using SuitAlteration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations_Payment
{
    public record CollectPaymentCommand : IRequest<int> 
    {
        public int EntityId { get; set; }
        public PaymentCollectionEntityType EntityType { get; set; } 
        public decimal Amount { get; set; } 
    }
}
