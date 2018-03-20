using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanAdjustmentDetail : BusinessObject
    {
        public StaffLoanAdjustmentDetail() { }

        public double Sno { get; set; }
        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string LoanProductCode { get; set; }
        public string LoanDateAd { get; set; }
        public string LoanDateBs { get; set; }
        public string LoanMaturityDate_Ad { get; set; }
        public string LoanMatureBs { get; set; }
        public double ApprovedLoanAmount { get; set; }
        public double TotalLoanAmount { get; set; }
        public string LoanPeriodType { get; set; }
        public double LoanPeriod { get; set; }
        public double GraceDays { get; set; }
        public double TotalInterest { get; set; }
        public double TotalPenalty { get; set; }
        public string EmployeeId { get; set; }
        public double InterestRate { get; set; }
        public double TotalPrincipalPaid { get; set; }
        public double TotalInterestPaid { get; set; }
        public string InstallmentPeriodType { get; set; }
        public int InstallmentPeriod { get; set; }
        public double PrincipalAmount { get; set; }
        public double YearNo { get; set; }
        public string CenterCode { get; set; }
        public string SavingAccountNo { get; set; }
        public string FiscalYear { get; set; }
        public string ContraAccount { get; set; }
        public string AdjustFromSaving { get; set; }
        public string TranOfficeCode { get; set; }
        public string ClientCenter { get; set; }
        public string EmployeeName { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public string CenterName { get; set; }
        public int AccountNo { get; set; }
        public string AccountDesc { get; set; }
        public string LoanProductName { get; set; }
        public string PeriodType { get; set; }
        public string CenterGroup { get; set; }
        public string SavAcDno { get; set; }
        public string SavProdName { get; set; }
        public string VoucherNo { get; set; }
        public string ClientNo { get; set; }
        public string DisburseDateAd { get; set; }
        public string DisburseDateBs { get; set; }
        public double LoanAmount { get; set; }
        public string ChequeNo { get; set; }
    }
}
