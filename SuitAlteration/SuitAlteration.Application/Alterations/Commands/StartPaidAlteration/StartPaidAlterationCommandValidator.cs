using FluentValidation;

namespace SuitAlteration.Application.Alterations.Commands.StartPaidAlteration
{
    public class StartPaidAlterationCommandValidator : AbstractValidator<StartPaidAlterationCommand>
    {
        public StartPaidAlterationCommandValidator()
        {
            RuleFor(v => v.AlterationId).GreaterThan(0);  
        } 
    }
}
