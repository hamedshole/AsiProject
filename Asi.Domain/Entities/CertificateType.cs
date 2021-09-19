using Asi.Domain.Common;
using System.Collections.Generic;

namespace Asi.Domain.Entities
{
    public partial class CertificateType : Entity
    {

        public string Title { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }

    }
}
