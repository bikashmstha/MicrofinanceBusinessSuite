using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class PaymentVoucherMasterDetail : BusinessObject
    {
        public PaymentVoucherMasterDetail() { }

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
        public string AccountCode { get; set; }
        public string MasterParticulars { get; set; }
        public string AccountNo { get; set; }
        public string AccountDesc { get; set; }
    }
}
