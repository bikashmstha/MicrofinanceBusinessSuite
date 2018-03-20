using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class InItemTransactionMaster : BusinessObject
    {
        public InItemTransactionMaster() { }

        public string FiscalYear { get; set; }
        public double SupplierCode { get; set; }
        public string LocationCode { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionDateNep { get; set; }
        public string Remarks { get; set; }
        public string Date1 { get; set; }
        public string Username { get; set; }
        public string PostedFlag { get; set; }
        public string ParentRefNo { get; set; }
        public string DeptCode { get; set; }
        public string EmpId { get; set; }
        public string MemoReceiptNo { get; set; }
        public string ApprovedTag { get; set; }
        public string TranOfficeCode { get; set; }
        public string CreTranOffice_Code { get; set; }
        public string InsertUpdate { get; set; }
        public string OutReferenceNo { get; set; }

        public List<ItemTransactionDetail> ItemTransactionDetails { get; set; }
    }
}
