using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Maintenance
{
    public class SavingProductDetail : BusinessObject
    {
        public SavingProductDetail() { }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductPrefix { get; set; }
        public string ProductTypeCode { get; set; }
        public string ProductType { get; set; }
        public string SavingAccountHead { get; set; }
        public string SavHead { get; set; }
        public string SavHeadNo { get; set; }
        public string IntSchemeCode { get; set; }
        public string IntDesc { get; set; }
        public string Compulsory { get; set; }
        public string ProductStartFrom { get; set; }
        public string ProductValidTill { get; set; }
        public string InterestAccountHead { get; set; }
        public string IntHead { get; set; }
        public string IntHeadNo { get; set; }
        public string PenaltyAccountHead { get; set; }
        public string PenHead { get; set; }
        public string PenHeadNo { get; set; }
        public string ClosingChargeAcc_Head { get; set; }
        public string CloseHead { get; set; }
        public double CompulsoryAmount { get; set; }
        public string CloseHeadNo { get; set; }
        public string TaxOnInt_Acc_Head { get; set; }
        public string TaxHead { get; set; }
        public string TaxHeadNo { get; set; }
        public string PeriodType { get; set; }
        public string IntCalcMethod { get; set; }
        public double TdsInterestPercentage { get; set; }
        public double MinBalance { get; set; }
        public double MinInterestBalance { get; set; }
        public double MaxWithdrawAmount { get; set; }
        public double MinAccountOpen_Amount { get; set; }
        public double AccountClosingCharge { get; set; }
        public string AccCloseIf_Loan_Exists { get; set; }
        public string FixedCollectionDay { get; set; }
        public string IntCapitalized { get; set; }
        public int InstallmentPeriod { get; set; }
        public double LessInterestPremature_End { get; set; }
        public double PenaltyLateInstallment { get; set; }
        public double PrematuredIntRatio { get; set; }
        public double InterestTaxableLimit { get; set; }
        public string InterestTaxable { get; set; }
        public int NoOfAccount_Open { get; set; }
        public string AccClosedIf_Client_Active { get; set; }
        public string OtherIncomeAc_Head { get; set; }
        public string OtherExpenseAc_Head { get; set; }
        public string ReferenceAccountY_N { get; set; }
        public string SavingProductFor { get; set; }
        public string Active { get; set; }
        public string MannualClosingY_N { get; set; }
        public int GraceDaysPenalty { get; set; }
        public int MaximumInactiveDays { get; set; }
        public string ActionForMax_Inactive_Days { get; set; }
        public string TotalDepositPeriod_Type { get; set; }
        public double TotalDepositPeriod { get; set; }
        public string TransferIntPeriodic { get; set; }
        public string ReferenceSavingProduct_Code { get; set; }
        public string SavingProductDesc { get; set; }
        public string AccurateIntAc_No { get; set; }
        public string AccurateIntAc_Head { get; set; }
        public string AccurateIntAc_Desc { get; set; }
        public string ProductCategoryCode { get; set; }
    }
}
