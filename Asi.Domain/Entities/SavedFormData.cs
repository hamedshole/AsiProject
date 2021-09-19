using Asi.Domain.Common;
using Asi.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class SavedFormData : Entity
    {
        [ForeignKey(nameof(Template))]
        public int TemplateId { get; set; }
        public FormTemplate Template { get; set; }

        public ICollection<FormDataGroup> Groups { get; set; }
    }
}
