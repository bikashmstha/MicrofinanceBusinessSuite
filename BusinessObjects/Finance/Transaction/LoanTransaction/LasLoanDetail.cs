using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class LasLoanDetail : BusinessObject
    {
        public LasLoanDetail() { }

        public string FiscalYear { get; set; }
        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string LoanDate { get; set; }
        public string LoanDate_Bs { get; set; }
        public string LoanMaturity_Date { get; set; }
        public string LoanMature_Bs { get; set; }
        public string LoanProduct_Code { get; set; }
        public string ClientNo { get; set; }
        public string LoanPurpose_Code { get; set; }
        public double ApprovedLoan_Amount { get; set; }
        public double TotalLoan_Amount { get; set; }
        public string LoanPeriod_Type { get; set; }
        public double LoanPeriod { get; set; }
        public double GraceDays { get; set; }
        public double TotalPrincipal_Outstanding { get; set; }
        public double TotalInterest { get; set; }
        public double TotalPenalty { get; set; }
        public string EmployeeId { get; set; }
        public int FundingAgency_Code { get; set; }
        public double InterestRate { get; set; }
        public string InterestCalc_Method { get; set; }
        public string LoanStatus { get; set; }
        public double TotalPrincipal_Paid { get; set; }
        public double TotalInterest_Paid { get; set; }
        public double InstallmentAmount { get; set; }
        public string InstallmentPeriod_Type { get; set; }
        public int InstallmentPeriod { get; set; }
        public double PrincipalAmount { get; set; }
        public double YearNo { get; set; }
        public double WithdrawalNo { get; set; }
        public string CenterCode { get; set; }
        public string SavingAccount_No { get; set; }
        public string AdjustFrom_Saving { get; set; }
        public string InsurancePolicy_No { get; set; }
        public string TranOffice_Code { get; set; }
        public string TransferDate { get; set; }
        public double FixedPrincipal_Amount { get; set; }
        public string FirstInstall_Date { get; set; }
        public string FirstInstall_Date_Bs { get; set; }
        public string ClientCenter { get; set; }
        public double FixedInterest_Amount { get; set; }
        public int NoOf_Installment { get; set; }
        public string EmployeeName { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public string CenterName { get; set; }
        public string LoanProduct_Name { get; set; }
        public string GroupName { get; set; }
        public string Address { get; set; }
        public string NomineeName { get; set; }
        public string SpouseName { get; set; }
        public string LoanPurpose_Desc { get; set; }
        public int CollectionDay { get; set; }
        public int AccountNo { get; set; }
        public string AccountDesc { get; set; }
        public string PeriodType { get; set; }
        public string CenterGroup { get; set; }
        public string SavAc_Dno { get; set; }
        public string SavProd_Name { get; set; }
        public string VoucherNo { get; set; }
        public string LoanAgainst_Saving_No { get; set; }
        public string LoanAgainst_Sav_Product_Code { get; set; }
        public string LoanAgainst_Sav_Product_Desc { get; set; }
        public double RowCount { get; set; }
    }
}
