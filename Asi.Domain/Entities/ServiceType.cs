using Asi.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class ServiceType : Entity
    {
        public string Title { get; set; }
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
    }
}
