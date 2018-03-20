using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class PublicAccountCloseDetail : BusinessObject
    {
        public PublicAccountCloseDetail() { }

        public string AccountNo { get; set; }
        public double WithdrawalNo { get; set; }
        public string ContraAccount { get; set; }
        public string WithdrawDateAd { get; set; }
        public string WithdrawDateBs { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string SavingAccountNo { get; set; }
        public int ContraAcNo { get; set; }
        public string AccountDesc { get; set; }
        public string ChequeNo { get; set; }
        public string PayeeName { get; set; }
        public double CurrentBalance { get; set; }
        public double ReceivedInterestAmount { get; set; }
        public string ReasonForClosing { get; set; }
        public string Remarks { get; set; }
        public double WithdrawAmount { get; set; }
        public double ClosingCharge { get; set; }
        public string VoucherNo { get; set; }
        public double UnpostInterest { get; set; }
        public double TaxAmount { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string AccountOpenDate { get; set; }
        public string AccountOperationType { get; set; }
        public string ImagePath { get; set; }
        public string JointImagePath { get; set; }
        public int HalfWayInt { get; set; }
        public double OtherIncomeExp_Amount { get; set; }
        public string OtherIncomeExp_Voucher_No { get; set; }
        public double AmtAtMature { get; set; }
        public double TotalBal { get; set; }
        public double MidTermInt_Rate { get; set; }
    }
}
