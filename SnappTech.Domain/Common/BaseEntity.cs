using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Domain.Common
{
    public abstract class BaseEntity
    {
        [NotMapped]
        public List<DomainEvent> Events { get; set; } = new List<DomainEvent>();
    }

}
