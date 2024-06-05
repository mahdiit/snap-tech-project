using FluentValidation;
using MediatR;
using SnappTech.Application.Contracts.Persistence;
using SnappTech.Application.Dto.Order.Command;
using SnappTech.Application.Dto.Product.Command.Add;
using SnappTech.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Handlers.Product
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        IProductRepository _productRepository;
        IValidator<CreateProductCommand> _validator;
        public CreateProductCommandHandler(
            IValidator<CreateProductCommand> validator,
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _validator = validator;
        }
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new AppException("Invalid request:" + string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var product = Domain.Entities.Product.Create(request.Product.Title,
                request.Product.InventoryCount,
                request.Product.Price,
                request.Product.Discount);

            await _productRepository.Add(product);
            await _productRepository.Save();

            return new CreateProductResult();
        }
    }
}
