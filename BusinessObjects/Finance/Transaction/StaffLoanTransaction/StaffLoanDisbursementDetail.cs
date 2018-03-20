using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanDisbursementDetail : BusinessObject
    {
        public StaffLoanDisbursementDetail() { }

        public string FiscalYear { get; set; }
        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string LoanDate { get; set; }
        public string LoanDateBs { get; set; }
        public string LoanMaturityDate { get; set; }
        public string LoanMatureBs { get; set; }
        public int FundingAgencyCode { get; set; }
        public string LoanProductCode { get; set; }
        public string ClientNo { get; set; }
        public string LoanPurposeCode { get; set; }
        public double ApprovedLoanAmount { get; set; }
        public double TotalLoanAmount { get; set; }
        public string LoanPeriodType { get; set; }
        public double LoanPeriod { get; set; }
        public double GraceDays { get; set; }
        public double TotalInterest { get; set; }
        public double TotalPenalty { get; set; }
        public string EmployeeId { get; set; }
        public string InterestCalcMethod { get; set; }
        public string LoanStatus { get; set; }
        public double TotalPrincipalPaid { get; set; }
        public double TotalInterestPaid { get; set; }
        public double InstallmentAmount { get; set; }
        public string InstallmentPeriodType { get; set; }
        public int InstallmentPeriod { get; set; }
        public double TotalPrincipalOutstanding { get; set; }
        public string TranOfficeCode { get; set; }
        public string TransferDate { get; set; }
        public double FixedPrincipalAmount { get; set; }
        public string FirstInstallDate { get; set; }
        public string FirstInstallDate_Bs { get; set; }
        public string ClientCenter { get; set; }
        public double FixedInterestAmount { get; set; }
        public int NoOfInstallment { get; set; }
        public string EmployeeName { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public string LoanProductName { get; set; }
        public double InterestRate { get; set; }
        public string Address { get; set; }
        public string LoanPurposeDesc { get; set; }
        public int AccountNo { get; set; }
        public string AccountDesc { get; set; }
        public string PeriodType { get; set; }
        public string SavProdName { get; set; }
        public string VoucherNo { get; set; }
        public string NewLoanDate { get; set; }
        public string NewLoanDate_Bs { get; set; }
        public string LastInterestCalc_Date { get; set; }
        public string LastInterestCalc_Date_Bs { get; set; }
        public string ChequeNo { get; set; }
    }
}
