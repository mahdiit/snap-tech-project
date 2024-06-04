using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Persistence.Common
{
    public class BaseContext : DbContext
    {
        #region Common        
        public virtual async Task<int> SaveChangesAsync()
        {
            //Audit
            foreach (var entry in base.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        break;
                    case EntityState.Modified:

                        break;
                }
            }

            return await base.SaveChangesAsync();
        }
        #endregion

        #region DbSet

        #endregion

    }
}
