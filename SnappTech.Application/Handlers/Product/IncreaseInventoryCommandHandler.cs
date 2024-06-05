using MediatR;
using SnappTech.Application.Contracts.Persistence;
using SnappTech.Application.Dto.Product.Command.IncreaseInventory;
using SnappTech.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Handlers.Product
{
    public class IncreaseInventoryCommandHandler : IRequestHandler<IncreaseInventoryCommand, IncreaseInventoryResult>
    {
        IProductRepository _productRepository;
        public IncreaseInventoryCommandHandler(IProductRepository produtRepository)
        {
            _productRepository = produtRepository;
        }

        public async Task<IncreaseInventoryResult> Handle(IncreaseInventoryCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.ProductId);
            if (product == null)
            {
                throw new AppException("Invalid product id");
            }

            product.IncreaseInventory(request.Amount);
            await _productRepository.Update(product);
            await _productRepository.Save();

            return new IncreaseInventoryResult();
        }
    }
}
