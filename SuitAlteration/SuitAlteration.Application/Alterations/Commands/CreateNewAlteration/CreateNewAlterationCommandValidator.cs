using FluentValidation;
using SuitAlteration.Domain.Common;
using SuitAlteration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations.Commands;
public class CreateNewAlterationCommandValidator : AbstractValidator<CreateNewAlterationCommand>
{
    public CreateNewAlterationCommandValidator()
    {
        RuleFor(v => v.Remarks)
            .MaximumLength(EntityRules.MaxLengthOfAnyReasonText)
            .NotEmpty();

        RuleFor(v => v.CustomerId).GreaterThan(0);

        RuleFor(v => v.SalesAssociateId).GreaterThan(0);

        RuleFor(v => v.AlterationDetails).NotEmpty();

        RuleForEach(v => v.AlterationDetails).SetValidator(new CreateNewAlterationDetailsValidator());


    }
}
