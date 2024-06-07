using Azure;
using BanketApp.Application.Contracts.Persistence.Common;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SnappTech.Application.Contracts.Infrastructure;
using SnappTech.Application.Contracts.Persistence;
using SnappTech.Application.Dto.Order.Command;
using SnappTech.Application.Dto.Product.Command.Add;
using SnappTech.Application.Dto.Product.Command.Create;
using SnappTech.Application.Dto.Product.Query;
using SnappTech.Application.Handlers.Order;
using SnappTech.Domain.Common;
using SnappTech.Infrastructure.Cache;
using SnappTech.Persistence.Common;
using SnappTech.Persistence.Context;
using SnappTech.Persistence.Repositories;
using System;
using Xunit.Abstractions;

namespace SnappTech.Application.Test
{
    public class OrderUnitTest : BaseTest
    {
        public OrderUnitTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task Buy_InvalidInputTest()
        {
            var buyCommand = new BuyCommand() { Order = new Dto.Order.CreateOrderDto() { Count = -10, ProductId = -101 } };            
            await Assert.ThrowsAsync<AppException>(async ()=> await _mediator.Send(buyCommand));

            output.WriteLine("Done");
        }

        [Fact]
        public async void Buy_ValidInputTest()
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

            //buy this product
            var buyCommand = new BuyCommand() { Order = new Dto.Order.CreateOrderDto() { Count = 5, ProductId = 1 } };
            var responseBuy = await _mediator.Send(buyCommand);
            Assert.Equal(0, responseBuy.StatusCode);

            //check inventory count
            var getProduct = new GetByIdQuery() { ProductId = 1 };
            var responseQuery = await _mediator.Send(getProduct);

            Assert.Equal(0, responseQuery.StatusCode);
            Assert.NotNull(responseQuery.Product);
            Assert.Equal(5, responseQuery.Product.InventoryCount);

            output.WriteLine("Done");
        }
    }
}