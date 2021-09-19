using Asi.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class FormTemplateRowMissMatchWord : Entity
    {
        public int Order { get; set; }
        public string Text { get; set; }
        [ForeignKey(nameof(Row))]
        public int RowId { get; set; }
        public FormTemplateRow Row { get; set; }
    }
}
