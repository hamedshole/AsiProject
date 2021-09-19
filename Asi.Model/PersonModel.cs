namespace Asi.Model
{
    public class PersonModel:BaseModel
    {
       
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public int ControlPercent { get; set; }
        public int AgancyPercent { get; set; }
        public int CertificatePercent { get; set; }
        public int MarketingPercent { get; set; }
        public int BranchPercent { get; set; }
        public string Signiture { get; set; }
    }
}
