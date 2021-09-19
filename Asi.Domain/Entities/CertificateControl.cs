using Asi.Domain.Common;
using Asi.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class CertificateControl : Entity
    {
        public bool Submitted { get; set; }
        public CertificateControl()
        {

        }
        [ForeignKey(nameof(Certificate))]
        public int CertificateId { get; set; }
        public Certificate Certificate { get; set; }
        public int ControlTime { get; set; }
        public DateTime ControlDate { get; set; }
        [ForeignKey(nameof(CertificateController))]
        public int? CertificateControllerId { get; set; }

        public int MainControllerId { get; set; }
        public virtual Person CertificateController { get; set; }
        [ForeignKey(nameof(MainControllerId))]
        public virtual Person MainController { get; set; }

        [ForeignKey(nameof(ControlForm))]
        public int ControlFormId { get; set; }
        [ForeignKey(nameof(Agancy))]
        public int? AgancyId { get; set; }
        public Person Agancy { get; set; }
        [ForeignKey(nameof(Marketing))]
        public int? MarketingId { get; set; }
        public Person Marketing { get; set; }
        [ForeignKey(nameof(BranchPerson))]
        public int? BranchId { get; set; }

        [ForeignKey(nameof(TechnicalManager))]
        public int? TechnicalManagerId { get; set; }
        public Person TechnicalManager { get; set; }
        public Person BranchPerson { get; set; }
        public Location Location { get; set; }
        public Link Link { get; set; }
        public ICollection<ControlImage> Images { get; set; }
        public SavedFormData ControlForm { get; set; }

    }
}
