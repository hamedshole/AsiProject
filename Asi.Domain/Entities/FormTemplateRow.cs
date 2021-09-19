using Asi.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class FormTemplateRow : Entity
    {
        public int Order { get; set; }
        [ForeignKey(nameof(TemplateGroup))]
        public int TemplateGroupId { get; set; }
        public FormTemplateGroup TemplateGroup { get; set; }
        public string FirstQuestion { get; set; }

        public string SecondQuestion { get; set; }

        public string ThirdQuestion { get; set; }

        public string ForthQuestion { get; set; }

        public ICollection<FormTemplateRowMissMatchWord> MissMatchWords { get; set; }
    }
}
