using SnappTech.Application.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Dto.Product.Command.IncreaseInventory
{
    public class IncreaseInventoryCommand : BaseRequest<IncreaseInventoryResult>
    {
        public int Amount { get; set; }
        public int ProductId { get; set; }
    }
}
