using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class MemoReturnReferenceNo : BusinessObject
    {
        public MemoReturnReferenceNo() { }

        public string ReferenceNo { get; set; }
        public string TransactionDate { get; set; }
        public string Remarks { get; set; }
        public string LocationCode { get; set; }
        public string DeptCode { get; set; }
        public string EmpId { get; set; }
        public string DeptName { get; set; }
        public string LocationDesc { get; set; }
        public string EmpName { get; set; }
        public string TranOfficeCode { get; set; }
    }
}
