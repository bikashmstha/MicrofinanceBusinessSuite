using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.SavingTransaction
{
    public class SavingAccountClosure : BusinessObject
    {
        public SavingAccountClosure() { }

        public string AccountNo { get; set; }
        public string WithdrawDate { get; set; }
        public double WithdrawAmount { get; set; }
        public string ChequeNo { get; set; }
        public string PayeeName { get; set; }
        public string ContraAccount { get; set; }
        public string Remarks { get; set; }
        public double ClosingCharge { get; set; }
        public string WithdrawType { get; set; }
        public string ReasonForClosing { get; set; }
        public string TranOfficeCode { get; set; }
        public double CurrentBalance { get; set; }
        public double TaxOnUnpostInterest { get; set; }
        public double UnpostInterest { get; set; }
        public double PenaltyAmount { get; set; }
        public double ReceivedInterest { get; set; }
        public string MidTermClosing { get; set; }
        public double MidTermBalance { get; set; }
        public double MidTermInterest { get; set; }
        public double MidTermTaxableAmount { get; set; }
        public double TdsDifference { get; set; }
        public double OtherIncomeAmount { get; set; }
        public double WaivedAmount { get; set; }
        public double PrematuredIntRatio { get; set; }
        public string MidTermClosingType { get; set; }
        public string InsertUpdate { get; set; }
        public string OutFiscalYear { get; set; }
        public double OutWithdrawalNo { get; set; }
    }
}
