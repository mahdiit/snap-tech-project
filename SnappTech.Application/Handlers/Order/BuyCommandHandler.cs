using FluentValidation;
using MediatR;
using SnappTech.Application.Contracts.Persistence;
using SnappTech.Application.Dto.Order.Command;
using SnappTech.Domain.Common;
using SnappTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Handlers.Order
{
    public class BuyCommandHandler : IRequestHandler<BuyCommand, BuyResult>
    {
        IValidator<BuyCommand> _validator;
        IProductRepository _productRepository;
        IOrderRepository _orderRepository;

        public BuyCommandHandler(IValidator<BuyCommand> validator, 
            IProductRepository productRepository, 
            IOrderRepository orderRepository)
        {         
            _validator = validator;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public async Task<BuyResult> Handle(BuyCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new AppException("Invalid request:" + string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var product = await _productRepository.GetById(request.Order.ProductId);
            if (product == null)
            {
                throw new AppException("Product not found");
            }

            var order = Domain.Entities.Order.Create(1001, product, request.Order.Count);

            await _orderRepository.Add(order);
            await _orderRepository.Save();

            return new BuyResult();
        }
    }
}
