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
    public class Order : BaseEntity
    {
        private Order()
        {
                
        }

        [Key]
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int Count { get; private set; }
        public int ProductPrice { get; private set; }
        public int BuyerId { get; private set; }
        public DateTime CreationDate { get; private set; }

        [ForeignKey("BuyerId")]
        [InverseProperty("Orders")]
        public virtual User Buyer { get; private set; } = null!;

        [ForeignKey("ProductId")]
        [InverseProperty("Orders")]
        public virtual Product Product { get; private set; } = null!;

        public static Order Create(int buyerId, Product product, int count)
        {
            product.DecreaseInventory(count);
            return new Order()
            {
                ProductId = product.Id,
                ProductPrice = product.TotalPriceWithDiscount,
                BuyerId = buyerId,
                CreationDate = DateTime.Now,
                Count = count
            };
        }
    }
}
