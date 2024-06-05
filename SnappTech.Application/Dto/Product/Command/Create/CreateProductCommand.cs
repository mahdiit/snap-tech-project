using SnappTech.Application.Dto.Base;
using SnappTech.Domain.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Dto.Product.Command.Add
{
    public class CreateProductCommand : BaseRequest<CreateProductResult>
    {
        public CreateProductDto Product { get; set; }
    }
}
