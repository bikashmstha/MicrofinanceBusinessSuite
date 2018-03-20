using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class GoodReceiptMasterDetail : BusinessObject
    {
        public GoodReceiptMasterDetail() { }

        public string ReferenceNo { get; set; }
        public string FiscalYear { get; set; }
        public int SupplierCode { get; set; }
        public string SupplierDesc { get; set; }
        public string LocationCode { get; set; }
        public string LocationDesc { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionDateNep { get; set; }
        public string Remarks { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string TranOfficeCode { get; set; }
    }
}
