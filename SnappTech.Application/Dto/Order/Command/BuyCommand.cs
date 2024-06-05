using SnappTech.Application.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Dto.Order.Command
{
    public class BuyCommand : BaseRequest<BuyResult>
    {
        public CreateOrderDto Order { get; set; }
    }
}
