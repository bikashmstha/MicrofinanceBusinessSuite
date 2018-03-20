using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MeLoanDisbursement : BusinessObject
    {
        public MeLoanDisbursement() { }

        public string LoanDate { get; set; }
        public string LoanMaturity_Date { get; set; }
        public string LoanProduct_Code { get; set; }
        public string ClientNo { get; set; }
        public string LoanPurpose_Code { get; set; }
        public double ApprovedLoan_Amount { get; set; }
        public double TotalLoan_Amount { get; set; }
        public string LoanPeriod_Type { get; set; }
        public double LoanPeriod { get; set; }
        public double GraceDays { get; set; }
        public string EmployeeId { get; set; }
        public double InterestRate { get; set; }
        public string InterestCalc_Method { get; set; }
        public string LoanClose_Date { get; set; }
        public string LoanStatus { get; set; }
        public string Rating { get; set; }
        public double InstallmentAmount { get; set; }
        public string RefAccount_No { get; set; }
        public string InstallmentPeriod_Type { get; set; }
        public double InstallmentPeriod { get; set; }
        public double PrincipalArrear { get; set; }
        public double PrincipalAmount { get; set; }
        public double YearNo { get; set; }
        public double WithdrawalNo { get; set; }
        public string ChkAdjust_Saving { get; set; }
        public string SavingAccount_No { get; set; }
        public string InsurancePolicy_No { get; set; }
        public string TranOffice_Code { get; set; }
        public double FixedPrincipal_Amount { get; set; }
        public string FirstInstall_Date { get; set; }
        public string ClientCenter { get; set; }
        public double FixedInterest_Amount { get; set; }
        public string ContraAccount { get; set; }
        public string Deduction1Code { get; set; }
        public string Deduction1Desc { get; set; }
        public double DeductionAmount1 { get; set; }
        public string Deduction2Code { get; set; }
        public string Deduction2Desc { get; set; }
        public double DeductionAmount2 { get; set; }
        public string Deduction3Code { get; set; }
        public string Deduction3Desc { get; set; }
        public double DeductionAmount3 { get; set; }
        public string Deduction4Code { get; set; }
        public string Deduction4Desc { get; set; }
        public double DeductionAmount4 { get; set; }
        public double NoOf_Installment { get; set; }
        public double FundingAgency_Code { get; set; }
        public string InsertUpdate { get; set; }
        public string OutFiscal_Year { get; set; }
        public string OutLoan_No { get; set; }
        public string OutLoan_Dno { get; set; }
    }
}
