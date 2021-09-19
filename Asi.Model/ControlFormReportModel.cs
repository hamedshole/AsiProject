using System;
using System.Collections.Generic;

namespace Asi.Model
{
    public class ControlFormReportModel
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
        public List<FormDataGroupModel> Groups { get; set; }
        public string CustomerSigniture { get; set; }
        public DateTime FirstTime { get; set; }
        public DateTime SecondTime { get; set; }
        public string ControllerName { get; set; }
        public string ControllerSigniture { get; set; }
    }
}
