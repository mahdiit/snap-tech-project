using SnappTech.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Domain.Entities
{
    public partial class Product : BaseEntity
    {
        [Key]
        public int Id { get; private set; }

        [StringLength(40)]
        public string Title { get; private set; } = null!;

        public int InventoryCount { get; private set; }
        public int Price { get; private set; }
        public decimal Discount { get; private set; } = 0;

        [InverseProperty("Product")]
        public ICollection<Order> Orders { get; private set; } = new List<Order>();

        public void Create(string title, int  inventoryCount, int price, decimal discount)
        {
            Title = title;
            InventoryCount = inventoryCount;
            Price = price;
            Discount = discount;
        }
    }
}
