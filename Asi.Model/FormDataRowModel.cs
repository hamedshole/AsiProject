using System.Collections.Generic;

namespace Asi.Model
{
    public class FormDataRowModel:BaseModel
    {
        public int TemplateId { get; set; }
        public int GroupId { get; set; }
        public List<string> MissMatchWords { get; set; }
        public string SelectedMissMatchWord { get; set; }
        public string FirstQuestion { get; set; }
        public string SecondQuestion { get; set; }
        public string ThirdQuestion { get; set; }
        public string ForthQuestion { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public string ForthAnswer { get; set; }
        public string FifthAnswer { get; set; }
        public FormDataRowModel()
        {
        }
    }
}
