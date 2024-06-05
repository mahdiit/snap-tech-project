using FluentValidation;
using SnappTech.Application.Contracts.Persistence;
using SnappTech.Application.Dto.Product.Command.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Dto.Product.Command.Create
{

    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator(IProductRepository productRepository)
        {
            RuleFor(p => p.Product)
                .NotNull()
                .SetValidator(new ProductDtoValidator(productRepository));
        }
    }
}
