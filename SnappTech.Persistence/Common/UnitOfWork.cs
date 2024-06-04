using BanketApp.Application.Contracts.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using SnappTech.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Persistence.Common
{
    public class UnitOfWork<TContext> : IUnitOfWrok where TContext : BaseContext
    {
        private readonly TContext _context;
        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public Task Add<T>(T entity) where T : BaseEntity
        {
            return Task.FromResult(_context.AddAsync(entity));
        }

        public Task Delete<T>(T entity) where T : BaseEntity
        {
            return Task.FromResult(_context.Set<T>().Remove(entity));
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<T> GetQuery<T>() where T : BaseEntity
        {
            return _context.Set<T>().AsQueryable();
        }

        public IQueryable<T> GetReadonlyQuery<T>() where T : BaseEntity
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
