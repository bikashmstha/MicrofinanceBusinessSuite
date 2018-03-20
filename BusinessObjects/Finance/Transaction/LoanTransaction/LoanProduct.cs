using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class LoanProduct : BusinessObject
    {
        public LoanProduct() { }

        public double LoanProductCode { get; set; }
        public string LoanProductName { get; set; }
        public double InterestRate { get; set; }
        public string IntCalcType { get; set; }
        public double RowCount { get; set; }


        public string LoanType { get; set; }
        public string LoanPrefix { get; set; }
        public double MLoanAmount { get; set; }
        public double MaxLoanAmount { get; set; }
        public double TerestRate { get; set; }
        public string TPayOn_Stallment { get; set; }
        public string TCalcType { get; set; }
        public double MLoanTerm_Months { get; set; }
        public double MaxLoanTerm_Months { get; set; }
        public double MaxGraceDays { get; set; }
        public string TCalcOn_Grace_Days { get; set; }
        public string PenaltyCalc { get; set; }
        public string PenaltyCalcType { get; set; }
        public double PenaltyCalcValue { get; set; }
        public string PenaltyCalcOn_Holiday { get; set; }
        public double PenaltyCalcTill_Months { get; set; }
        public double GraceDaysPenalty { get; set; }
        public double MBal_Savg_Account { get; set; }
        public string PrcipalAccountHead { get; set; }
        public string TerestAccountHead { get; set; }
        public string PenaltyAccountHead { get; set; }
        public string YearWiseLoan_Limit { get; set; }
        public double MaxFixedLoan_Pct { get; set; }
        public string FixedCollectionDay { get; set; }
        public string TReceivableAcc_Head { get; set; }
        public string PenReceivableAcc_Head { get; set; }
        public string SuspenseAccHead { get; set; }
        public double DisplaySeq { get; set; }
        public string LoanCategory { get; set; }
        public string DemandYN { get; set; }
        public string Active { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTill { get; set; }
        public double NoOfAccount_Open { get; set; }
        public string CibCode { get; set; }
        public string SavProdCode { get; set; }
        public string ApprovalT { get; set; }
        public string User1 { get; set; }

        public List<LoanProductDeduction> LoanProductDeductions { get; set; }
    }
}
