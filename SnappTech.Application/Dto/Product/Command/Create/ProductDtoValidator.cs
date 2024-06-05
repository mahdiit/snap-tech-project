using FluentValidation;
using SnappTech.Application.Contracts.Persistence;
using SnappTech.Domain.Dto.Product;

namespace SnappTech.Application.Dto.Product.Command.Create
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator(IProductRepository productRepository)
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("title required")
                .MaximumLength(40).WithMessage("title 40 character only")
                .MustAsync(async (title, token) => !(await productRepository.TitleExist(title)))
                .WithMessage("product exist");

            RuleFor(p => p.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("disount min: 0")
                .LessThanOrEqualTo(100).WithMessage("discount max : 100");
        }
    }
}
