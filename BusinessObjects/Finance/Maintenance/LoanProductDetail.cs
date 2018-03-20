using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Maintenance
{
    public class LoanProductDetail : BusinessObject
    {
        public LoanProductDetail() { }

        public string LoanProductCode { get; set; }
        public string LoanProductName { get; set; }
        public string LoanType { get; set; }
        public string LoanPrefix { get; set; }
        public double MinLoanAmount { get; set; }
        public double MaxLoanAmount { get; set; }
        public double InterestRate { get; set; }
        public string IntPayOn_Installment { get; set; }
        public string IntCalcType { get; set; }
        public double MinLoanTerm_Months { get; set; }
        public double MaxLoanTerm_Months { get; set; }
        public double MaxGraceDays { get; set; }
        public string IntCalcOn_Grace_Days { get; set; }
        public string PenaltyCalc { get; set; }
        public string PenaltyCalcType { get; set; }
        public double PenaltyCalcValue { get; set; }
        public string PenaltyCalcOn_Holiday { get; set; }
        public double PenaltyCalcTill_Months { get; set; }
        public double GraceDaysPenalty { get; set; }
        public double MinBalanceIn_Saving_Account { get; set; }
        public string PrincipalAccountHead { get; set; }
        public string PrincipalAccountNo { get; set; }
        public string PrincipalAccountDesc { get; set; }
        public string InterestAccountHead { get; set; }
        public string InterestAccountNo { get; set; }
        public string DemandYN { get; set; }
        public string Active { get; set; }
        public int NoOfAccount_Open { get; set; }
        public string InterestAccountDesc { get; set; }
        public string PenaltyAccountHead { get; set; }
        public string PenaltyAccountNo { get; set; }
        public string PenaltyAccountDesc { get; set; }
        public string YearWiseLoan_Limit { get; set; }
        public double MaxFixedLoan_Pct { get; set; }
        public string FixedCollectionDay { get; set; }
        public string IntReceivableAcc_Head { get; set; }
        public string IntReceiveAccount_No { get; set; }
        public string IntReceiveAccount_Desc { get; set; }
        public string PenReceivableAcc_Head { get; set; }
        public string PenReceiveAccount_No { get; set; }
        public string PenReceiveAccount_Desc { get; set; }
        public string SuspenseAccHead { get; set; }
        public string SuspenseAccountNo { get; set; }
        public string SuspenseAccountDesc { get; set; }
        public double DisplaySeq { get; set; }
        public string LoanCategory { get; set; }
        public string ProductValidFrom { get; set; }
        public string ProductValidTill { get; set; }
        public string CibCode { get; set; }
        public string SavingProductType_Code { get; set; }
        public string ApprovalPercentage { get; set; }
        public string ProductType { get; set; }
    }
}
