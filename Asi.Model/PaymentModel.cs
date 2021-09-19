using System;

namespace Asi.Model
{
    public class PaymentModel : BaseModel
    {
        public int ReceiptNumber { get; set; }
        public int FactorNumber { get; set; }
        public DateTime ReceiptDate { get; set; }
        public long Amount { get; set; }
    }
}
