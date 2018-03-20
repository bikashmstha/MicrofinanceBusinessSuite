using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class ReceiptVoucherMasterDetail : BusinessObject
    {
        public ReceiptVoucherMasterDetail() { }

        public string VoucherNo { get; set; }
        public string FiscalYear { get; set; }
        public string TransactionDateAd { get; set; }
        public string NepaliDate { get; set; }
        public string Particulars { get; set; }
        public string Remarks { get; set; }
        public string ChequeBillNo { get; set; }
        public string ApprovedDateBs { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedFlag { get; set; }
        public string TranOfficeCode { get; set; }
        public string VoucherType { get; set; }
        public double Amount { get; set; }
    }
}
