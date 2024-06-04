using SnappTech.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanketApp.Application.Contracts.Persistence.Common
{
    public interface IUnitOfWrok: IDisposable
    {
        #region Repo        
        IQueryable<T> GetQuery<T>() where T : BaseEntity;
        IQueryable<T> GetReadonlyQuery<T>() where T : BaseEntity;
        Task Add<T>(T entity) where T : BaseEntity;        
        Task Delete<T>(T entity) where T : BaseEntity;       
        #endregion
        
        Task Save();
    }
}
