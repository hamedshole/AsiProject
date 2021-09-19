using Asi.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class FormTemplate : Entity
    {
        [ForeignKey(nameof(CertificateType))]
        public int CertificateTypeId { get; set; }
        public CertificateType CertificateType { get; set; }
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string StandradRefference { get; set; }
        public string FormCode { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ToolCode { get; set; }
        public ICollection<FormTemplateGroup> Groups { get; set; }
    }
}
