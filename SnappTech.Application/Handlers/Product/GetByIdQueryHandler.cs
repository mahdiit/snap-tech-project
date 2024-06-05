using Mapster;
using MediatR;
using SnappTech.Application.Contracts.Persistence;
using SnappTech.Application.Dto.Product.Query;
using SnappTech.Domain.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Handlers.Product
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdResult>
    {
        IProductRepository _productRepository;
        public GetByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GetByIdResult> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetByIdWithCache(request.ProductId, TimeSpan.FromDays(1));
            if (result == null)
            {
                return new GetByIdResult()
                {
                    StatusCode = 400,
                    Message = "data not found"
                };
            }

            return new GetByIdResult()
            {
                Product = result.Adapt<ProductDto>()
            };
        }
    }
}
