using Asi.Model.ValueObjects;
using System;
using System.Collections.Generic;

namespace Asi.Model
{
    public class RequestCertificateModel : BaseModel
    {
        public int ItemId { get; set; }
        public int DepartmentId { get; set; }
        public int ServiceTypeId { get; set; }
        public int CertificateTypeId { get; set; }
        public int MainControllerId { get; set; }
        public DateTime ControlDate { get; set; }
        public int ControlTime { get; set; }
        public string ControlTimeText { get; set; }
        public List<RequestCertificateControlModel> FormDatas { get; set; }
        public int ProvinenceId { get; set; }
        public Company Company { get; set; }
        public string Image { get; set; }
    }
}
