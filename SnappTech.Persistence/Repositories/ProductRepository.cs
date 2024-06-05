using BanketApp.Application.Contracts.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using SnappTech.Application.Contracts.Infrastructure;
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
        IMemoryCacheService _cacheService;
        public ProductRepository(IUnitOfWrok db, IMemoryCacheService cacheService)
        {
            _db = db;
            _cacheService = cacheService;
        }

        public Task<Product?> GetById(int id)
        {
            return _db.GetQuery<Product>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Product?> GetByIdReadonly(int id)
        {
            return _db.GetQuery<Product>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Product?> GetByIdWithCache(int id, TimeSpan cacheDuration)
        {
            return _cacheService.GetData($"SYSDATA:PRODUCT:{id}", () => GetByIdReadonly(id), cacheDuration);
        }

        public Task<bool> TitleExist(string title)
        {
            return _db.GetReadonlyQuery<Product>().AnyAsync(x => x.Title == title);
        }

        public async Task Add(Product product)
        {
            await _db.Add(product);
        }

        public Task Update(Product product)
        {
            return _cacheService.Remove($"SYSDATA:PRODUCT:{product.Id}");
        }

        public Task Save()
        {
            return _db.Save();
        }
    }
}
