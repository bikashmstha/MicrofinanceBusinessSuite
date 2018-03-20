using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class CalLoanBalanceStatus : BusinessObject
    {
        public CalLoanBalanceStatus() { }

        public string OfficeCode { get; set; }
        public string LoanNo { get; set; }
        public string RepayDate { get; set; }
        public string RepayDateAD { get; set; }
        public double PastPr_Amount { get; set; }
        public double CurrPr_Amount { get; set; }
        public double PastT_Amount { get; set; }
        public double CurrT_Amount { get; set; }
        public double PenaltyAmount { get; set; }
        public double TotalStallment_Amount { get; set; }
        public double PrcipalBalance { get; set; }
        public double TerestBalance { get; set; }
        public double PenaltyBalance { get; set; }
        public double TotalBalance { get; set; }
        public string ResultCode { get; set; }
        public string ResultMsg { get; set; }
    }
}
