using Asi.Domain.Common;
using System.Collections.Generic;

namespace Asi.Domain.Entities
{
    public partial class Province : Entity
    {

        public string Title { get; private set; }
        public virtual ICollection<Certificate> Certificates { get; set; }

    }
}
