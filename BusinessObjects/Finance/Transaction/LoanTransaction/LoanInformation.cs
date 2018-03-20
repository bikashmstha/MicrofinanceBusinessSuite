using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class LoanInformation : BusinessObject
    {
        public LoanInformation() { }

        public string FirstInstallmentDate { get; set; }
        public string FirstInstallmentDate_Np { get; set; }
        public string MaturityDate { get; set; }
        public string MaturityDateNp { get; set; }
        public string NoOfInstallment { get; set; }
        public string InstallmentAmt { get; set; }
        public string FixedPrinAmt { get; set; }
        public string FixedIntAmt { get; set; }
        public string Deduction1Code { get; set; }
        public string Deduction1Desc { get; set; }
        public string DeductionAmount1 { get; set; }
        public string ChoiceDeductY_N1 { get; set; }
        public string Deduction2Code { get; set; }
        public string Deduction2Desc { get; set; }
        public string DeductionAmount2 { get; set; }
        public string ChoiceDeductY_N2 { get; set; }
        public string Deduction3Code { get; set; }
        public string Deduction3Desc { get; set; }
        public string DeductionAmount3 { get; set; }
        public string ChoiceDeductY_N3 { get; set; }
        public string Deduction4Code { get; set; }
        public string Deduction4Desc { get; set; }
        public string DeductionAmount4 { get; set; }
        public string ChoiceDeductY_N4 { get; set; }
        public string NetDeductionAmount { get; set; }
    }
}
