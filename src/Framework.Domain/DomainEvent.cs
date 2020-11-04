using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain
{
    public class DomainEvent
    {
        public Guid Id{ get; set; }
        public DateTime CreatedAt{ get; set; }
    }
}
