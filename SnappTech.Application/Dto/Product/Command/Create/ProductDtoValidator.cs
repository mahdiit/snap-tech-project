using FluentValidation;
using SnappTech.Application.Contracts.Persistence;
using SnappTech.Domain.Dto.Product;

namespace SnappTech.Application.Dto.Product.Command.Create
{
    public class ProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public ProductDtoValidator(IProductRepository productRepository)
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("title required")
                .MaximumLength(40).WithMessage("title 40 character only")
                .MustAsync(async (title, token) => !(await productRepository.TitleExist(title)))
                .WithMessage("product exist");
        }
    }
}
