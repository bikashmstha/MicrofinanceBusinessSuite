using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MfAdditionalLoanDisbursement : BusinessObject
    {
        public MfAdditionalLoanDisbursement() { }

        public string LoanNo { get; set; }
        public string LoanProduct_Code { get; set; }
        public string DisburseDate { get; set; }
        public double LoanAmount { get; set; }
        public string ContraAccount { get; set; }
        public string EmployeeId { get; set; }
        public string TranOffice_Code { get; set; }
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
        public string ChkAdjust_Saving { get; set; }
        public string SavingAccount_No { get; set; }
        public string User1 { get; set; }
        public string InsertUpdate { get; set; }
        public string OutFiscal_Year { get; set; }
        public double OutS_No { get; set; }
    }
}
