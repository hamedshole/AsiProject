using Asi.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class Payment : Entity
    {

        [ForeignKey(nameof(Certificate))]
        public int CertificateId { get; set; }
        public Certificate Certificate { get; set; }
        public int ReceiptNumber { get; set; }
        public int FactorNumber { get; set; }
        public DateTime ReceiptDate { get; set; }
        public long Amount { get; set; }

    }
}
