using Asi.Model.ValueObjects;
using System;
using System.Collections.Generic;

namespace Asi.Model
{
    public class CertificateModel:BaseModel
    {
        public CertificateModel()
        {

        }
        public string FileNumber { get
            {
                return string.Format("RS-{0}", Id);
            } 
        }
        public int HologramNumber { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceType { get; set; }
        public int ItemId { get; set; }
        public string Item { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime CertificationDate { get; set; }
        public DateTime CertificateExpirationDate { get; set; }
        public int CertificateTypeId { get; set; }
        public string CertificateType { get; set; }
        public int ControlReffrenceId { get; set; }
        public string ControlRefference { get; set; }
        public int ProvinceId { get; set; }
        public string Province { get; set; }
        public Company Company{ get; set; }
        public string Image { get; set; }
        public ICollection<CertificateControlModel> Controls { get; set; }
        public ICollection<PaymentModel> Payments { get; set; }
    }
}
