using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.SavingTransaction
{
    public class AccountOpenDetail : BusinessObject
    {
        public AccountOpenDetail() { }

        public double WithdrawAmount { get; set; }
        public double ClosingCharge { get; set; }
        public string VoucherNo { get; set; }
        public double UnpostInterest { get; set; }
        public double TaxAmount { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string AccountOpenDate { get; set; }
        public string ImagePath { get; set; }
        public int HalfWayInt { get; set; }
        public double MidTermBalance { get; set; }
        public double OtherIncomeExpAmount { get; set; }
        public string OtherIncomeExpVoucherNo { get; set; }
        public double TotalBal { get; set; }
        public double MidTermIntRate { get; set; }
        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public string AccountDesc { get; set; }
        public string ChequeNo { get; set; }
        public string PayeeName { get; set; }
        public double CurrentBalance { get; set; }
        public double ReceivedInterestAmount { get; set; }
        public string ReasonForClosing { get; set; }
        public string Remarks { get; set; }
        public string ClientName { get; set; }
        public string SavingAccountNo { get; set; }
        public int ContraAcNo { get; set; }
        public string AccountNo { get; set; }
        public double WithdrawalNo { get; set; }
        public string ContraAccount { get; set; }
        public string WithdrawDate { get; set; }
        public string WithdrawDateBs { get; set; }
        public string ClientCode { get; set; }
    }
}
