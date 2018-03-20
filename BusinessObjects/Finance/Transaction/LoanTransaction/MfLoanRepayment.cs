using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MfLoanRepayment : BusinessObject
    {
        public MfLoanRepayment() { }

        public string LoanNo { get; set; }
        public string PaymentDate { get; set; }
        public double PaidAmount { get; set; }
        public double TotalBalance { get; set; }
        public double TotalPrincipalOutstanding { get; set; }
        public double PastPrincipalDue { get; set; }
        public double CurrentPrincipalSchedule { get; set; }
        public double PastInterestDue { get; set; }
        public double InterestAmount { get; set; }
        public double PenaltyAmount { get; set; }
        public double PrincipalPaidAmount { get; set; }
        public double InterestPaidAmount { get; set; }
        public double PenaltyPaidAmount { get; set; }
        public string AdjustFromSaving { get; set; }
        public string SavingAccountNo { get; set; }
        public string ContraAccount { get; set; }
        public string VoucherNo { get; set; }
        public string EmployeeId { get; set; }
        public double TotalPrincipalPaidAmount { get; set; }
        public double TotalInterestPaidAmount { get; set; }
        public double TotalPenaltyPaidAmount { get; set; }
        public string Remarks { get; set; }
        public string TranOfficeCode { get; set; }
        public string User1 { get; set; }
        public string InsertUpdate { get; set; }
        public string OutFiscalYear { get; set; }
        public double OutLoanRepaymentNo { get; set; }
        public string OutResultCode { get; set; }
        public string OutResultMsg { get; set; }
    }
}
