using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class PublicSavingWithdraw : BusinessObject
    {
        public PublicSavingWithdraw() { }

        public string AccountNo { get; set; }
        public string WithdrawDate { get; set; }
        public double WithdrawAmount { get; set; }
        public string ChequeNo { get; set; }
        public string PayeeName { get; set; }
        public string ContraAccount { get; set; }
        public string Remarks { get; set; }
        public string VoucherNo { get; set; }
        public string WithdrawType { get; set; }
        public double MaxWithdrawAmount { get; set; }
        public string TranOfficeCode { get; set; }
        public string AcOfficeCode { get; set; }
        public string ValueDate { get; set; }
        public double ChargeAmount { get; set; }
        public string ChargeType { get; set; }
        public string ChargeSource { get; set; }
        public string User1 { get; set; }
        public string InsertUpdate { get; set; }
        public string OutFiscalYear { get; set; }
        public double OutWithdrawalNo { get; set; }
    }
}
