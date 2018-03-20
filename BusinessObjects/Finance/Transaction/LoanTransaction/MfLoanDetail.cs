using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MfLoanDetail : BusinessObject
    {
        public MfLoanDetail() { }

        public string FiscalYear { get; set; }
        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string LoanDate { get; set; }
        public string LoanDateBs { get; set; }
        public string SectorDesc { get; set; }
        public string LoanMaturityDate { get; set; }
        public string LoanMatureBs { get; set; }
        public string HusbandName { get; set; }
        public string FatherInlawName { get; set; }
        public string LoanProductCode { get; set; }
        public string ClientNo { get; set; }
        public string LoanPurposeCode { get; set; }
        public double ApprovedLoanAmount { get; set; }
        public double TotalLoanAmount { get; set; }
        public string LoanPeriodType { get; set; }
        public double LoanPeriod { get; set; }
        public double GraceDays { get; set; }
        public double TotalPrincipalOutstanding { get; set; }
        public double TotalInterest { get; set; }
        public double TotalPenalty { get; set; }
        public string EmployeeId { get; set; }
        public string FundingAgencyCode { get; set; }
        public string InterestCalcMethod { get; set; }
        public string LoanStatus { get; set; }
        public double TotalPrincipalPaid { get; set; }
        public double TotalInterestPaid { get; set; }
        public double InstallmentAmount { get; set; }
        public string InstallmentPeriodType { get; set; }
        public int InstallmentPeriod { get; set; }
        public double PrincipalAmount { get; set; }
        public double YearNo { get; set; }
        public string WithdrawalNo { get; set; }
        public string CenterCode { get; set; }
        public string SavingAccountNo { get; set; }
        public string AdjustFromSaving { get; set; }
        public string InsurancePolicyNo { get; set; }
        public string TranOfficeCode { get; set; }
        public string TransferDate { get; set; }
        public double FixedPrincipalAmount { get; set; }
        public string FirstInstallDate { get; set; }
        public string FirstInstallDateBs { get; set; }
        public string ClientCenter { get; set; }
        public double FixedInterestAmount { get; set; }
        public int NoOfInstallment { get; set; }
        public string EmployeeName { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public string CenterName { get; set; }
        public string LoanProductName { get; set; }
        public double InterestRate { get; set; }
        public string GroupName { get; set; }
        public string Address { get; set; }
        public string NomineeName { get; set; }
        public string SpouseName { get; set; }
        public string LoanPurposeDesc { get; set; }
        public int CollectionDay { get; set; }
        public string AccountNo { get; set; }
        public string AccountDesc { get; set; }
        public string PeriodType { get; set; }
        public string CenterGroup { get; set; }
        public string SavAcDno { get; set; }
        public string SavProdName { get; set; }
        public string VoucherNo { get; set; }
    }
}
