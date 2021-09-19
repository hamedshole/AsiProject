using Asi.Model.ValueObjects;
using System;
using System.Collections.Generic;

namespace Asi.Model
{
    public class CertificateControlModel : BaseModel

    {
        public int CertificateId { get; set; }
        public DateTime Time { get; set; }
        public string ControlTime { get; set; }
        public int MainControllerId { get; set; }
        public string MainControllerName { get; set; }
        public int CertificateControllerId { get; set; }
        public string CertificateControllerName { get; set; }
        public int TechnicalManagerId { get; set; }
        public string TechnicalManagerName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int AgancyId { get; set; }
        public string AgancyName { get; set; }
        public int MarketingId { get; set; }
        public string MarketingName { get; set; }
        public int ControlFormId { get; set; }
        public FormDataModel ControlForm { get; set; }
        public ControlLocation Location{ get; set; }
        public ControlLink Link { get; set; }
        public List<string> ItemImages { get; set; }
    }
}
