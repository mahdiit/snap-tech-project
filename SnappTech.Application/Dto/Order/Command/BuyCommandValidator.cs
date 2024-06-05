using FluentValidation;

namespace SnappTech.Application.Dto.Order.Command
{
    public class BuyCommandValidator : AbstractValidator<BuyCommand>
    {
        public BuyCommandValidator()
        {
            RuleFor(p => p.Order)
                .NotNull()
                .SetValidator(new CreateOrderValidator());
        }
    }
}
