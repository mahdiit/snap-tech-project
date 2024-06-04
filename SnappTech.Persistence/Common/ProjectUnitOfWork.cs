using BanketApp.Application.Contracts.Persistence.Common;
using SnappTech.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Persistence.Common
{
    public class ProjectUnitOfWork : UnitOfWork<ProjectContext>, IUnitOfWrok
    {
        public ProjectUnitOfWork(ProjectContext context) : base(context)
        {

        }
    }
}
