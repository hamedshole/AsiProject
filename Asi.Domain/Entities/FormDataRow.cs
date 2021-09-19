using Asi.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class FormDataRow : Entity
    {
        public int Order { get; set; }

        public int GroupId { get; set; }
        [ForeignKey(nameof(GroupId))]
        public virtual FormDataGroup Group { get; set; }

        public int TemplateId { get; set; }
        [ForeignKey(nameof(TemplateId))]
        public FormTemplateRow Template { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public string ForthAnswer { get; set; }
        public string FifthAnswer { get; set; }
        public string MissMatchWord { get; set; }

    }
}
