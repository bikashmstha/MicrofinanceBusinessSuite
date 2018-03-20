using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class MemoApprovalDetail : BusinessObject
    {
        public MemoApprovalDetail() { }

        public string TransactionNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string UnitCode { get; set; }
        public double TransactionQuantity { get; set; }
        public double TransactionCost { get; set; }
        public double Total { get; set; }
        public string Remarks { get; set; }
    }
}
