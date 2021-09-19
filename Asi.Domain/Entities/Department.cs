using Asi.Domain.Common;
using System.Collections.Generic;

namespace Asi.Domain.Entities
{
    public partial class Department : Entity
    {
        public string Title { get; set; }
        public virtual ICollection<ServiceType> ServiceTypes { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public Department()
        {

        }
    }
}
