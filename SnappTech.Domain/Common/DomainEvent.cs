using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Domain.Common
{
    public record DomainEvent(string EventType, string EventContent);
    
}
