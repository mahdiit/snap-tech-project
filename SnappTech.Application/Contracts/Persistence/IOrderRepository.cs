using SnappTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Contracts.Persistence
{
    public interface IOrderRepository
    {
        Task Add(Order order);
        Task Save();
    }
}
