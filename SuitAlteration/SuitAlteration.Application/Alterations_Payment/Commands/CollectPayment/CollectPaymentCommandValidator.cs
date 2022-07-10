using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations_Payment.Commands.CollectPayment
{ 
    public class CollectPaymentCommandValidator : AbstractValidator<CollectPaymentCommand>
    { 
        public CollectPaymentCommandValidator()
        {  
            RuleFor(v => v.EntityId).GreaterThan(0);

            RuleFor(v => v.Amount).GreaterThan(0);

            RuleFor(v => v.EntityType).IsInEnum(); 
        }
    }
}
