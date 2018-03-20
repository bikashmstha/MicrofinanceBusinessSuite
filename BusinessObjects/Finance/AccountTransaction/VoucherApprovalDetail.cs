using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class VoucherApprovalDetail : BusinessObject
    {
        public VoucherApprovalDetail() { }

        public string VoucherNo { get; set; }
        public int TransactionId { get; set; }
        public string AccountCode { get; set; }
        public string Particulars { get; set; }
        public string DrCrFlag { get; set; }
        public string Remarks { get; set; }
        public int AccountNo { get; set; }
        public string AccountDesc { get; set; }
        public double DrAmount { get; set; }
        public double CrAmount { get; set; }
    }
}
