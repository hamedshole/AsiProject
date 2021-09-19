using Asi.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class Item : Entity
    {
        public Item()
        {

        }
        public string Title { get; set; }
        [ForeignKey(nameof(ServiceType))]
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
        public ICollection<FormTemplate> Formtemplates { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
    }
}
