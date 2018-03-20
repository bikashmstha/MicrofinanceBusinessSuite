using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class GlTransactionDetail : BusinessObject
    {
        public GlTransactionDetail() { }

        public string VoucherNo { get; set; }
        public string TransactionDate { get; set; }
        public double TransactionId { get; set; }
        public string TranOfficeCode { get; set; }
        public string AccountCode { get; set; }
        public string Particulars { get; set; }
        public double Amount { get; set; }
        public string DrCrFlag { get; set; }
        public string Remarks { get; set; }
        public string CurrencyCode { get; set; }
        public string TranType { get; set; }
        public string DmlType { get; set; }
    }
}
