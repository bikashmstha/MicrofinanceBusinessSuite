using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MeLoanRepayDetail : BusinessObject
    {
        public MeLoanRepayDetail() { }

        public string TranOffice_Code { get; set; }
        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public string LoanProduct_Code { get; set; }
        public string ProductDesc { get; set; }
        public string ClientName { get; set; }
        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public double RepaymentNo { get; set; }
        public double PaidAmount { get; set; }
        public double PrincipalPaid_Amount { get; set; }
        public double InterestPaid_Amount { get; set; }
        public double PenaltyPaid_Amount { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentBs { get; set; }
        public double TotalPrincipal_Outstanding { get; set; }
        public double InstallmentAmount { get; set; }
        public double PastPrincipal_Due { get; set; }
        public double CurrentPrincipal_Schedule { get; set; }
        public double PastInterest_Due { get; set; }
        public double InterestAmount { get; set; }
        public double PenaltyAmount { get; set; }
        public string EmployeeId { get; set; }
        public string ContraAccount { get; set; }
        public string ChequeNo { get; set; }
        public string AdjustFrom_Saving { get; set; }
        public string EmpName { get; set; }
        public int AccountNo { get; set; }
        public string AccountDesc { get; set; }
        public string SavingAccount_No { get; set; }
        public string VoucherNo { get; set; }
    }
}
