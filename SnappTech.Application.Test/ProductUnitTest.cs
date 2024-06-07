using SnappTech.Application.Dto.Product.Command.Add;
using SnappTech.Application.Dto.Product.Command.IncreaseInventory;
using SnappTech.Application.Dto.Product.Query;
using SnappTech.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace SnappTech.Application.Test
{
    public class ProductUnitTest : BaseTest
    {
        public ProductUnitTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            
        }

        [Fact]
        public async Task IncreaseInventory()
        {
            var addProduct = new CreateProductCommand()
            {
                Product = new Dto.Product.CreateProductDto()
                {
                    Discount = 10,
                    InventoryCount = 10,
                    Price = 10000,
                    Title = "Product 1"
                }
            };
            //Add sample product
            var responseProduct = await _mediator.Send(addProduct);
            Assert.Equal(0, responseProduct.StatusCode);

            var invalidIncrease = new IncreaseInventoryCommand() { Amount = -10, ProductId = 1 };
            await Assert.ThrowsAnyAsync<AppException>(async () => await _mediator.Send(invalidIncrease));

            var validIncrease = new IncreaseInventoryCommand() { Amount = 5, ProductId = 1 };
            var response = await _mediator.Send(validIncrease);
            Assert.Equal(0, response.StatusCode);

            var checkCount = new GetByIdQuery() { ProductId = 1 };  
            var responseQuery = await _mediator.Send(checkCount);
            Assert.Equal(0, responseQuery.StatusCode);
            Assert.NotNull(responseQuery.Product);
            Assert.Equal(15, responseQuery.Product.InventoryCount);
        }
    }
}
