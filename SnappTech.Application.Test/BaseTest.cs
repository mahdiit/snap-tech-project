using BanketApp.Application.Contracts.Persistence.Common;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SnappTech.Application.Contracts.Infrastructure;
using SnappTech.Application.Contracts.Persistence;
using SnappTech.Application.Dto.Order.Command;
using SnappTech.Application.Dto.Product.Command.Add;
using SnappTech.Application.Dto.Product.Command.Create;
using SnappTech.Application.Handlers.Order;
using SnappTech.Infrastructure.Cache;
using SnappTech.Persistence.Common;
using SnappTech.Persistence.Context;
using SnappTech.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SnappTech.Application.Test
{
    public class BaseTest : IDisposable
    {
        public IServiceCollection _services;
        public IServiceProvider _app;
        public IMediator _mediator;
        //public readonly ITestOutputHelper output;

        public BaseTest()
        {
            _services = new ServiceCollection();
            _app = _services
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(BuyCommandHandler).Assembly))
                .AddDbContext<ProjectContext>(opt =>
                {
                    opt.UseInMemoryDatabase("TestDb");
                })
                .AddMemoryCache()
                .AddSingleton<IMemoryCacheService, MemoryCacheService>()
                .AddScoped<IUnitOfWrok, ProjectUnitOfWork>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IValidator<CreateProductCommand>, CreateProductValidator>()
                .AddScoped<IValidator<BuyCommand>, BuyCommandValidator>()
                //.AddSingleton<ITestOutputHelper, TestOutputHelper>()
                .BuildServiceProvider();

            _mediator = _app.GetRequiredService<IMediator>();
            //output = _app.GetRequiredService<ITestOutputHelper>();
        }
        public void Dispose()
        {
            var dbContext = _app.GetService<ProjectContext>();
            dbContext.Database.EnsureDeleted();
        }
    }
}
