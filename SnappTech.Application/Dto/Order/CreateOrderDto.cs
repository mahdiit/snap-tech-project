using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Dto.Order
{
    public class CreateOrderDto
    {
        public int ProductId { get; set; }
        public int Count { get; set; }

    }
}
