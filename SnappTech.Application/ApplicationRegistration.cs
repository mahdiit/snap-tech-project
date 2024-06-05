using FluentValidation;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnappTech.Application.Dto.Order.Command;
using SnappTech.Application.Dto.Product.Command.Add;
using SnappTech.Application.Dto.Product.Command.Create;
using SnappTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IValidator<CreateProductCommand>, CreateProductValidator>();
            services.AddScoped<IValidator<BuyCommand>, BuyCommandValidator>();

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
