using Asi.Model.ValueObjects;
using System;
using System.Collections.Generic;

namespace Asi.Model
{
    public  class RequestCertificateControlModel:BaseModel
    {
        public int CertificateId { get; set; }
        public DateTime Time { get; set; }
        public int ControlTime { get; set; }
        public string MainController { get; set; }
        public int MainControllerId { get; set; }
        public FormDataModel ControlForm { get; set; }
        public ControlLink Link { get; set; }
        public ControlLocation Location { get; set; }
        public List<string> ItemImage { get; set; }
    }
}
