using BanketApp.Application.Contracts.Persistence.Common;
using SnappTech.Application.Contracts.Persistence;
using SnappTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        IUnitOfWrok _db;
        public OrderRepository(IUnitOfWrok db)
        {
            _db = db;
        }

        public Task Add(Order order)
        {
            return _db.Add(order);
        }

        public Task Save()
        {
            return _db.Save();
        }
    }

}
