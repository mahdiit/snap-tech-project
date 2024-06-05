using BanketApp.Application.Contracts.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnappTech.Application.Contracts.Persistence;
using SnappTech.Persistence.Common;
using SnappTech.Persistence.Context;
using SnappTech.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Persistence
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectContext>();
            services.AddScoped<IUnitOfWrok, ProjectUnitOfWork>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
