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
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int ProductPrice { get; set; }
        public int BuyerId { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("BuyerId")]
        [InverseProperty("Orders")]
        public virtual User Buyer { get; set; } = null!;

        [ForeignKey("ProductId")]
        [InverseProperty("Orders")]
        public virtual Product Product { get; set; } = null!;

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
