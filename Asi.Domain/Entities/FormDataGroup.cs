using Asi.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class FormDataGroup : Entity
    {
        public int Order { get; set; }
        [ForeignKey(nameof(SavedFormData))]
        public int SavedFormDataId { get; set; }

        public virtual SavedFormData SavedFormData { get; set; }
        [ForeignKey(nameof(Template))]
        public int TemplateId { get; set; }
        public FormTemplateGroup Template { get; set; }
        public ICollection<FormDataRow> Answers { get; set; }
        public string Description { get; set; }

    }
}
