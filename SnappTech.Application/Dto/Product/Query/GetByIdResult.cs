using SnappTech.Application.Dto.Base;
using SnappTech.Domain.Dto.Product;

namespace SnappTech.Application.Dto.Product.Query
{
    public class GetByIdResult : BaseResponse
    {
        public ProductDto? Product { get; set; }
    }
}
