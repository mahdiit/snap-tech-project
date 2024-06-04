using BanketApp.Application.Contracts.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using SnappTech.Application.Contracts.Persistence;
using SnappTech.Domain.Common;
using SnappTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        IUnitOfWrok _db;
        public ProductRepository(IUnitOfWrok db)
        {
            _db = db;
        }

        public Task<bool> ProductTitleExist(string title)
        {
            return _db.GetReadonlyQuery<Product>().AnyAsync(x => x.Title == title);
        }

        public async Task AddProduct(Product product)
        {
            await _db.Add(product);
            await _db.Save();
        }
    }
}
