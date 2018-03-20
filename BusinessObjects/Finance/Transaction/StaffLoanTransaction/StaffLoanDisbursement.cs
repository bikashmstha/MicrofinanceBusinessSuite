using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanDisbursement : BusinessObject
    {
        public StaffLoanDisbursement() { }

        public string ChequeNo { get; set; }
        public string LoanDate { get; set; }
        public string LoanMaturityDate { get; set; }
        public string LoanProductCode { get; set; }
        public string ClientNo { get; set; }
        public string LoanPurposeCode { get; set; }
        public double ApprovedLoanAmount { get; set; }
        public double TotalLoanAmount { get; set; }
        public string LoanPeriodType { get; set; }
        public double LoanPeriod { get; set; }
        public double GraceDays { get; set; }
        public string EmployeeId { get; set; }
        public double InterestRate { get; set; }
        public string InterestCalcMethod { get; set; }
        public string LoanCloseDate { get; set; }
        public string LoanStatus { get; set; }
        public string Rating { get; set; }
        public double InstallmentAmount { get; set; }
        public string RefAccountNo { get; set; }
        public string InstallmentPeriodType { get; set; }
        public double InstallmentPeriod { get; set; }
        public double PrincipalArrear { get; set; }
        public double PrincipalAmount { get; set; }
        public double YearNo { get; set; }
        public double WithdrawalNo { get; set; }
        public string ChkAdjustSaving { get; set; }
        public string SavingAccountNo { get; set; }
        public string InsurancePolicyNo { get; set; }
        public string TranOfficeCode { get; set; }
        public double FixedPrincipalAmount { get; set; }
        public string FirstInstallDate { get; set; }
        public string ClientCenter { get; set; }
        public double FixedInterestAmount { get; set; }
        public string ContraAccount { get; set; }
        public string Deduction1Code { get; set; }
        public string Deduction1Desc { get; set; }
        public double? DeductionAmount1 { get; set; }
        public string Deduction2Code { get; set; }
        public string Deduction2Desc { get; set; }
        public double? DeductionAmount2 { get; set; }
        public string Deduction3Code { get; set; }
        public string Deduction3Desc { get; set; }
        public double? DeductionAmount3 { get; set; }
        public string Deduction4Code { get; set; }
        public string Deduction4Desc { get; set; }
        public double? DeductionAmount4 { get; set; }
        public double NoOfInstallment { get; set; }
        public double FundingAgencyCode { get; set; }
        public string User1 { get; set; }
        public string InsertUpdate { get; set; }
        public string OutFiscalYear { get; set; }
        public string OutLoanNo { get; set; }
        public string OutLoanDno { get; set; }
    }
}
