using Asi.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class FormTemplateGroup : Entity
    {
        public int Order { get; set; }
        [ForeignKey(nameof(Form))]
        public int FormId { get; set; }
        public FormTemplate Form { get; set; }
        public bool HasNote { get; set; }
        public bool IsCheckbox { get; set; }
        public string Title { get; set; }
        public bool HasSubtitle { get; set; }
        public string Subtitle { get; set; }
        public ICollection<FormTemplateAnswerColumn> AnswerColumns { get; set; }
        public ICollection<FormTemplateQuestionHeader> QuestionHeaders { get; set; }
        public ICollection<FormTemplateRow> Questions { get; set; }
    }
}
