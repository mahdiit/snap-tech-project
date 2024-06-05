using SnappTech.Application.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Dto.Product.Query
{
    public class GetByIdQuery : BaseRequest<GetByIdResult>
    {
        public int ProductId { get; set; }
    }
}
