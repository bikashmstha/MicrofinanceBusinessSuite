using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class VoucherApprovalMaster : BusinessObject
    {
        public VoucherApprovalMaster() { }

        public string VoucherNo { get; set; }
        public string FiscalYear { get; set; }
        public string Particulars { get; set; }
        public string TransactionDate { get; set; }
        public string NepDate { get; set; }
        public string VoucherType { get; set; }
        public double Amount { get; set; }
    }
}
