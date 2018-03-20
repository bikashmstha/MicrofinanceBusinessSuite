using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class ReverseVoucher : BusinessObject
    {
        public ReverseVoucher() { }

        public string VoucherNo { get; set; }
        public string FiscalYear { get; set; }
        public string Particulars { get; set; }
        public string TransactionDate { get; set; }
        public string BsDate { get; set; }
        public string VoucherNoAgainst { get; set; }
        public string TranOfficeCode { get; set; }
        public double RowCount { get; set; }
    }
}
