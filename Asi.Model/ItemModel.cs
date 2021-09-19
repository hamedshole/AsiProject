using System.Collections.Generic;

namespace Asi.Model
{
    public class ItemModel:BaseModel
    {
        
        public string Title { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceType { get; set; }
        public int FormId { get; set; }
        public List<FormTemplateModel> FormTemplates { get; set; }
    }
}
