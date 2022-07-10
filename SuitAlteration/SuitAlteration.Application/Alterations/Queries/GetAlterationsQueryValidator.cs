using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations.Queries
{ 
    public class GetAlterationsQueryValidator : AbstractValidator<GetAlterationsQuery>
    {
        public GetAlterationsQueryValidator()
        {
            RuleFor(v => v.Status).IsInEnum();
        }
    }
}
