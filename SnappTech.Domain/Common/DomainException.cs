using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Domain.Common
{
    public class DomainException : AppException
    {
        public string DomainType { get; set; }
        public DomainException(string type, string message): base(message)
        {
            DomainType = type;
        }
    }
}
