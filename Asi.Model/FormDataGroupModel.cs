using System.Collections.Generic;

namespace Asi.Model
{
    public class FormDataGroupModel:BaseModel
    {
        public int TemplateId { get; set; }
        public bool IsCheckBox { get; set; }
        public bool HasNote { get; set; }
        public string Title { get; set; }
        public bool HasSubtitle { get; set; }
        public string Subtitle { get; set; }
        public List<string> AnswerColumns { get; set; }
        public List<string> QuestionHeaders { get; set; }
        public List<FormDataRowModel> Questions { get; set; }
        public string Description { get; set; }
       

        public FormDataGroupModel()
        {
        }
    }
}
