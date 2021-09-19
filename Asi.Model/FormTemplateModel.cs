using System;
using System.Collections.Generic;

namespace Asi.Model
{
    public class FormTemplateModel:BaseModel
    {
        public int ItemId { get; set; }
        public string CertificateType { get; set; }
        public int CertificateTypeId { get; set; }
        public string StandardRefference { get; set; }
        public string FormCode { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ToolCode { get; set; }
        public List<FormTemplateGroupModel> Groups { get; set; }
        
    }
}
