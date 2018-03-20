using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class QueryOnSavingAccountClose : BusinessObject
    {
        public QueryOnSavingAccountClose() { }

        public string AccountNo { get; set; }
        public string SavingProductCode { get; set; }
        public string WithdrawDate { get; set; }
        public string Username { get; set; }
        public string OutPrematuredInt_Ratio { get; set; }
        public string OutMidTerm_Closing_Type { get; set; }
        public string OutAccountOperator_Type { get; set; }
        public string OutAccountOpen_Date { get; set; }
        public string OutMaturityDate { get; set; }
        public double OutAmountAt_Maturity { get; set; }
        public double OutPresentBalance_With_Int { get; set; }
        public double OutPresentBal_Without_Int { get; set; }
        public double OutMidTerm_Bal_With_Int { get; set; }
        public double OutTdsLimit_Amount { get; set; }
        public double OutUnpostInterest { get; set; }
        public double OutTaxableUnpost_Interest { get; set; }
        public double OutTdsOn_Unpost_Interest { get; set; }
        public double OutReceivedInterest_Amount { get; set; }
        public double OutMidTerm_Int_Amt { get; set; }
        public double OutMidTerm_Taxable_Amount { get; set; }
        public double OutMidTerm_Tds_Amount { get; set; }
        public double OutTdsDifference { get; set; }
        public double OutClosingCharge { get; set; }
        public double OutOtherIncome { get; set; }
        public double OutWithdrawAmount { get; set; }
        public double OutWaivedAmount { get; set; }
    }
}
