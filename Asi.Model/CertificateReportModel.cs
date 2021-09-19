using System;
using System.Collections.Generic;

namespace Asi.Model
{
    public class CertificateReportModel
    {
        public string ItemName { get; set; }
        public string FormCode { get; set; }
        public DateTime ReviewDate { get; set; }
        public string FileNumber { get; set; }
        public string ToolCode { get; set; }
        public string StandardRefference { get; set; }
        public DateTime ControlDate { get; set; }
        public string EmployerName { get; set; }
        public string EmployerAddress { get; set; }
        public string ControllerSigniture { get; set; }
        public List<FormDataGroupModel> Groups { get; set; }
        public List<ControlReport> Controls { get; set; }
    }
}
