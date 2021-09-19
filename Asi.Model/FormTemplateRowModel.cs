using System.Collections.Generic;

namespace Asi.Model
{
    public class FormTemplateRowModel:BaseModel
    {
        public string FirstQuestion { get; set; }
        public string SecondQuestion { get; set; }
        public string ThirdQuestion { get; set; }
        public string ForthQuestion { get; set; }
        public List<string> MissMatchWords { get; set; }
    }
}
