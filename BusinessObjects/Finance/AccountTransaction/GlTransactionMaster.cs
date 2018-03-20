using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class GlTransactionMaster : BusinessObject
    {
        public GlTransactionMaster() { }

        public string FiscalYear { get; set; }
        public string TransactionDate { get; set; }
        public string Particulars { get; set; }
        public string ModifiedFlag { get; set; }
        public string AuditedFlag { get; set; }
        public string AuditedDate { get; set; }
        public string AuditedBy { get; set; }
        public string Remarks { get; set; }
        public double ApprovedNo { get; set; }
        public string ApprovedFlag { get; set; }
        public string PostedYN { get; set; }
        public string ReferenceNo { get; set; }
        public string TranOfficeCode { get; set; }
        public string VoucherType { get; set; }
        public string CloseFlag { get; set; }
        public string VoucherNoAgainst { get; set; }
        public string ChequeBillNo { get; set; }
        public string VoucherNoReference { get; set; }
        public double VoucherSeqNo { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedDateBs { get; set; }
        public string ApprovedBy { get; set; }
        public double TotalDrAmount { get; set; }
        public string InsertUpdate { get; set; }
        public string OutVoucherNo { get; set; }
        public double OutHistSeq_No { get; set; }

        public List<GlTransactionDetail> GlTransactionDetail { get; set; }
    }
}
