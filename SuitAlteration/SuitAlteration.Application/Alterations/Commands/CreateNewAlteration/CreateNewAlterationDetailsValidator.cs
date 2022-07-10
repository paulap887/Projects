using FluentValidation;
using SuitAlteration.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations.Commands
{
    public class CreateNewAlterationDetailsValidator : AbstractValidator<AlterationDetails>
    {
        public CreateNewAlterationDetailsValidator()
        {
            RuleFor(v => v.AdjustmentInCms).InclusiveBetween(EntityRules.MinimumMeasurementForAltering,EntityRules.MaximumMeasurementForAltering);

            RuleFor(v => v.SuitPieceType).IsInEnum();

            RuleFor(v => v.SuitPieceTypeSide).IsInEnum();

        }
      
    }
}
