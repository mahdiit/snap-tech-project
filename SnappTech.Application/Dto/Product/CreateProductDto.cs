using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Dto.Product
{
    public class CreateProductDto
    {
        public string Title { get; set; }
        public int InventoryCount { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
    }
}
