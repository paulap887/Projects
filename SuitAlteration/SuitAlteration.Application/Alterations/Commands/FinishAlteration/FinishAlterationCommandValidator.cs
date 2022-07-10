using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations.Commands.FinishAlteration
{ 
    public class FinishAlterationCommandValidator : AbstractValidator<FinishAlterationCommand>
    {
        public FinishAlterationCommandValidator()
        {
            RuleFor(v => v.AlterationId).GreaterThan(0);
        }
    }
}
