using Asi.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public class ControlImage : Entity
    {
        public CertificateControl Control { get; set; }
        [ForeignKey(nameof(Control))]
        public int ControlId { get; set; }
        public string Path { get; set; }
    }
}
