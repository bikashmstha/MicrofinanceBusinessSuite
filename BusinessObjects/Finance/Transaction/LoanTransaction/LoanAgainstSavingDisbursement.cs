using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class LoanAgainstSavingDisbursement : BusinessObject
    {
        public LoanAgainstSavingDisbursement() { }

        public string PLoan_Date { get; set; }
        public string PLoan_Maturity_Date { get; set; }
        public string PLoan_Product_Code { get; set; }
        public string PClient_No { get; set; }
        public string PLoan_Purpose_Code { get; set; }
        public double PApproved_Loan_Amount { get; set; }
        public double PTotal_Loan_Amount { get; set; }
        public string PLoan_Period_Type { get; set; }
        public double PLoan_Period { get; set; }
        public double PGrace_Days { get; set; }
        public string PEmployee_Id { get; set; }
        public double PInterest_Rate { get; set; }
        public string PInterest_Calc_Method { get; set; }
        public string PLoan_Close_Date { get; set; }
        public string PLoan_Status { get; set; }
        public string PRating { get; set; }
        public double PInstallment_Amount { get; set; }
        public string PRef_Account_No { get; set; }
        public string PInstallment_Period_Type { get; set; }
        public double PInstallment_Period { get; set; }
        public double PPrincipal_Arrear { get; set; }
        public double PPrincipal_Amount { get; set; }
        public double PYear_No { get; set; }
        public double PWithdrawal_No { get; set; }
        public string PChk_Adjust_Saving { get; set; }
        public string PSaving_Account_No { get; set; }
        public string PInsurance_Policy_No { get; set; }
        public string PTran_Office_Code { get; set; }
        public double PFixed_Principal_Amount { get; set; }
        public string PFirst_Install_Date { get; set; }
        public string PClient_Center { get; set; }
        public double PFixed_Interest_Amount { get; set; }
        public string PContra_Account { get; set; }
        public string PDeduction1_Code { get; set; }
        public string PDeduction1_Desc { get; set; }
        public double PDeduction_Amount1 { get; set; }
        public string PDeduction2_Code { get; set; }
        public string PDeduction2_Desc { get; set; }
        public double PDeduction_Amount2 { get; set; }
        public string PDeduction3_Code { get; set; }
        public string PDeduction3_Desc { get; set; }
        public double PDeduction_Amount3 { get; set; }
        public string PDeduction4_Code { get; set; }
        public string PDeduction4_Desc { get; set; }
        public double PDeduction_Amount4 { get; set; }
        public double PNo_Of_Installment { get; set; }
        public double PFunding_Agency_Code { get; set; }
        public string PLoan_Against_Saving_No { get; set; }
        public string PUser1 { get; set; }
        public string PInsert_Update { get; set; }
        public string VOut_Fiscal_Year { get; set; }
        public string VOut_Loan_No { get; set; }
        public string VOut_Loan_Dno { get; set; }
        public string VOut_Result_Code { get; set; }
    }
}
