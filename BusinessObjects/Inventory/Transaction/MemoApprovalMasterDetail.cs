using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class MemoApprovalMasterDetail : BusinessObject
    {
        public MemoApprovalMasterDetail() { }

        public string ReferenceNo { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionDateNep { get; set; }
        public string LocationCode { get; set; }
        public string LocationDesc { get; set; }
        public string DeptCode { get; set; }
        public string DeptDesc { get; set; }
        public string VoucherNo { get; set; }
        public string ApprovedTag { get; set; }
        public double Quantity { get; set; }
        public double TotalCost { get; set; }
        public string TransactionType { get; set; }
    }
}
