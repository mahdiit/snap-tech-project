using SnappTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Contracts.Persistence
{
    public interface IProductRepository
    {
        Task<Product?> GetById(int id);
        Task<Product?> GetByIdReadonly(int id);
        Task<Product?> GetByIdWithCache(int id, TimeSpan cacheDuration);
        Task<bool> TitleExist(string title);
        Task Add(Product product);
        Task Update(Product product);
        Task Save();
    }
}
