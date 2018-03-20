using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanRepayDetail : BusinessObject
    {
        public StaffLoanRepayDetail() { }

        public string TranOfficeCode { get; set; }
        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public string LoanProductCode { get; set; }
        public string ProductDesc { get; set; }
        public string ClientName { get; set; }
        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public double RepaymentNo { get; set; }
        public double PaidAmount { get; set; }
        public double PrincipalPaidAmount { get; set; }
        public double InterestPaidAmount { get; set; }
        public double PenaltyPaidAmount { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentBs { get; set; }
        public double TotalPrincipalOutstanding { get; set; }
        public double InstallmentAmount { get; set; }
        public double PastPrincipalDue { get; set; }
        public double CurrentPrincipalSchedule { get; set; }
        public double PastInterestDue { get; set; }
        public double InterestAmount { get; set; }
        public double PenaltyAmount { get; set; }
        public string EmployeeId { get; set; }
        public string ContraAccount { get; set; }
        public string ChequeNo { get; set; }
        public string AdjustFromSaving { get; set; }
        public string EmpName { get; set; }
        public int AccountNo { get; set; }
        public string AccountDesc { get; set; }
        public string SavingAccountNo { get; set; }
        public string VoucherNo { get; set; }
    }
}
