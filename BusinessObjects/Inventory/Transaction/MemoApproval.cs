using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class MemoApproval : BusinessObject
    {
        public MemoApproval() { }

        public string ReferenceNo { get; set; }
        public string ApprovedTag { get; set; }
        public string VoucherNo { get; set; }
        public string Username { get; set; }
        public string Date1 { get; set; }
    }
}
