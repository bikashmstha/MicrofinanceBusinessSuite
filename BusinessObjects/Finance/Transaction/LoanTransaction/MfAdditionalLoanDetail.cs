using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MfAdditionalLoanDetail : BusinessObject
    {
        public MfAdditionalLoanDetail() { }

        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string LoanProduct_Code { get; set; }
        public string LoanDate { get; set; }
        public string LoanDate_Bs { get; set; }
        public string LoanMaturity_Date { get; set; }
        public string LoanMature_Bs { get; set; }
        public string ClientNo { get; set; }
        public double ApprovedLoan_Amount { get; set; }
        public double TotalLoan_Amount { get; set; }
        public string LoanPeriod_Type { get; set; }
        public double LoanPeriod { get; set; }
        public double GraceDays { get; set; }
        public double TotalInterest { get; set; }
        public double TotalPenalty { get; set; }
        public string EmployeeId { get; set; }
        public double TotalPrincipal_Paid { get; set; }
        public double TotalInterest_Paid { get; set; }
        public string InstallmentPeriod_Type { get; set; }
        public int InstallmentPeriod { get; set; }
        public double PrincipalAmount { get; set; }
        public double YearNo { get; set; }
        public string CenterCode { get; set; }
        public string SavingAccount_No { get; set; }
        public string FiscalYear { get; set; }
        public string ContraAccount { get; set; }
        public string AdjustFrom_Saving { get; set; }
        public string TranOffice_Code { get; set; }
        public string ClientCenter { get; set; }
        public string EmployeeName { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public string CenterName { get; set; }
        public double InterestRate { get; set; }
        public int AccountNo { get; set; }
        public string AccountDesc { get; set; }
        public string LoanProduct_Name { get; set; }
        public string PeriodType { get; set; }
        public string CenterGroup { get; set; }
        public string SavAc_Dno { get; set; }
        public string SavProd_Name { get; set; }
        public string VoucherNo { get; set; }
        public string DisburseDate { get; set; }
        public string DisburseDate_Bs { get; set; }
        public double LoanAmount { get; set; }
    }
}
