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
        #region Anemic Model
        [Key]
        public int Id { get; private set; }

        [StringLength(40)]
        public string Title { get; private set; } = null!;

        public int InventoryCount { get; private set; }
        public int Price { get; private set; }
        public int Discount { get; private set; } = 0;

        [InverseProperty("Product")]
        public ICollection<Order> Orders { get; private set; } = new List<Order>();
        #endregion

        [NotMapped]
        public int TotalPriceWithDiscount
        {
            get
            {
                return Price - Convert.ToInt32(Convert.ToDecimal(Price) * (Convert.ToDecimal(Discount)/ 100.0m));
            }
        }


        #region Methods
        public void Create(string title, int inventoryCount, int price, int discount)
        {
            Title = title;
            InventoryCount = inventoryCount;
            Price = price;
            Discount = discount;
        }

        public void IncreaseInventory(int amount)
        {
            if (amount <= 0)
                throw new DomainException("IncreaseInventory", "Invalid increase amount");

            InventoryCount += amount;
        }
        #endregion
    }
}
