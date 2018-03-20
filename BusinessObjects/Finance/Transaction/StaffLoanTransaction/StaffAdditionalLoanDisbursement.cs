using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class StaffAdditionalLoanDisbursement : BusinessObject
    {
        public StaffAdditionalLoanDisbursement() { }

        public string ChequeNo { get; set; }
        public string LoanNo { get; set; }
        public string LoanProductCode { get; set; }
        public string DisburseDate { get; set; }
        public double LoanAmount { get; set; }
        public string ContraAccount { get; set; }
        public string EmployeeId { get; set; }
        public string TranOfficeCode { get; set; }
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
        public string ChkAdjustSaving { get; set; }
        public string SavingAccountNo { get; set; }
        public string User1 { get; set; }
        public string InsertUpdate { get; set; }
        public string OutFiscalYear { get; set; }
        public double OutSNo { get; set; }
    }
}
