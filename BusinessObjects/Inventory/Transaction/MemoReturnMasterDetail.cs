using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class MemoReturnMasterDetail : BusinessObject
    {
        public MemoReturnMasterDetail() { }

        public string ReferenceNo { get; set; }
        public string FiscalYear { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string LocationCode { get; set; }
        public string LocationDesc { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionDateNep { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string MemoReceiptNo { get; set; }
        public string Remarks { get; set; }
        public string ParentRefNo { get; set; }
        public string TranOfficeCode { get; set; }
    }
}
