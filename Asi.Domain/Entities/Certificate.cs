using Asi.Domain.Common;
using Asi.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class Certificate : Entity
    {
        public bool ExpirationNotified { get; set; }
        public bool NeedToBeCompleted { get; set; }
        public bool Rejected { get; set; }
        public bool Accepted { get; set; }
        public int? HologramNumber { get; set; }
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [ForeignKey(nameof(CertificateType))]
        public int CertificateTypeId { get; set; }
        public CertificateType CertificateType { get; set; }
        [ForeignKey(nameof(ServiceType))]
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? CertificationDate { get; set; }
        public DateTime? CertificateExpirationDate { get; set; }
        [ForeignKey(nameof(Province))]
        public int ProvinceIdId { get; set; }
        [ForeignKey(nameof(RefferenceForm))]
        public int? RefferenceFormId { get; set; }
        public Province Province { get; set; }
        public Company Company { get; set; }
        public string Image { get; set; }
        public SavedFormData RefferenceForm { get; set; }
        public ICollection<CertificateControl> Controls { get; set; }
        public ICollection<Payment> Payments { get; set; }


    }
}
