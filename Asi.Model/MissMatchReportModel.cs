using System;
using System.Collections.Generic;

namespace Asi.Model
{
    public class MissMatchReportModel:BaseModel
    {
        public string FormCode { get; set; }
        public string FileNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public DateTime ControlDate{ get; set; }
        public string Company { get; set; }
        public string Item { get; set; }
        public string ControlTime { get; set; }
        public string ControlRefference { get; set; }
        public string Address { get; set; }
        public List<FormDataRowModel> Properties { get; set; }
        public List<string> MissMatchWords { get; set; }
    }
}
