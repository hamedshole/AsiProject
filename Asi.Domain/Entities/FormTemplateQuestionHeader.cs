using Asi.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class FormTemplateQuestionHeader : Entity
    {
        public int Order { get; set; }
        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }
        public FormTemplateGroup Group { get; set; }
        public string Title { get; set; }
    }
}