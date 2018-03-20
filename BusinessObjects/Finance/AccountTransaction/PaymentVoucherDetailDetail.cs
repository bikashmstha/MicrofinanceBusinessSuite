using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class PaymentVoucherDetailDetail : BusinessObject
    {
        public PaymentVoucherDetailDetail() { }

        public int TransactionId { get; set; }
        public string AccountCode { get; set; }
        public string Particulars { get; set; }
        public double Amount { get; set; }
        public string DrCrFlag { get; set; }
        public string Remarks { get; set; }
        public string CurrencyCode { get; set; }
        public string TranType { get; set; }
        public string DmlType { get; set; }
        public int AccountNo { get; set; }
        public string AccountDesc { get; set; }
        public string TranOfficeCode_Det { get; set; }
        public double DrAmount { get; set; }
        public double CrAmount { get; set; }
    }
}
