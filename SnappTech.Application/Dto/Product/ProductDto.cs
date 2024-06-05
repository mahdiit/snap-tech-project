using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Domain.Dto.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int TotalPriceWithDiscount { get; set; }
        public string Title { get; set; }
        public int InventoryCount { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
    }
}
