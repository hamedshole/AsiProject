using System.Collections.Generic;

namespace Asi.Model
{
    public class FormDataModel:BaseModel
    {
        public string StandardRefference { get; set; }
        public int CertificateTypeId { get; set; }
        public string CertificateType { get; set; }
        public int TemplateId { get; set; }
        public List<FormDataGroupModel> Groups { get; set; }
    }
}
