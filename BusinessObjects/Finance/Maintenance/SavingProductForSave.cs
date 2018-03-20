using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Maintenance
{
    public class SavingProductForSave:BusinessObject
    {
        public SavingProductForSave() { }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductPrefix { get; set; }
        public string ProductTypeCode { get; set; }
        public string IntSchemeCode { get; set; }
        public string IntCalcMethod { get; set; }
        public double MinBalance { get; set; }
        public double MinInterestBalance { get; set; }
        public double MaxWithdrawAmount { get; set; }
        public double LessInterestPremature_End { get; set; }
        public string PeriodType { get; set; }
        public double InstallmentPeriod { get; set; }
        public double PenaltyLateInstallment { get; set; }
        public double GraceDaysPenalty { get; set; }
        public double PenaltyCalcTill { get; set; }
        public string SavingAccountHead { get; set; }
        public string AccurateIntAccount_Head { get; set; }
        public string InterestAccountHead { get; set; }
        public string PenaltyAccountHead { get; set; }
        public string ProductStartFrom { get; set; }
        public string ProductValidTill { get; set; }
        public double TdsInterestPercentage { get; set; }
        public double IntCalcPeriod { get; set; }
        public string Compulsory { get; set; }
        public double MinAccountOpen_Amount { get; set; }
        public double AccountClosingCharge { get; set; }
        public string AccCloseIf_Loan_Exists { get; set; }
        public string ClosingChargeAcc_Head { get; set; }
        public string TaxOnInt_Acc_Head { get; set; }
        public string FixedCollectionDay { get; set; }
        public double PrematuredIntRatio { get; set; }
        public double InterestTaxableLimit { get; set; }
        public string InterestTaxable { get; set; }
        public double MinTermInt_Rate { get; set; }
        public string IntCapitalized { get; set; }
        public double NoOfAccount_Open { get; set; }
        public string AccClosedIf_Client_Active { get; set; }
        public string OtherIncomeAc_Head_No { get; set; }
        public string OtherExpenseAc_Head_No { get; set; }
        public string ReferenceAccountY_N { get; set; }
        public string SavingProductFor { get; set; }
        public string Active { get; set; }
        public string ManualClosing { get; set; }
        public string ThirdPartyData { get; set; }
        public string TotalDepositPeriod_Type { get; set; }
        public double TotalDepositPeriod { get; set; }
        public string ReferenceSavProduct_Code { get; set; }
        public string TransferIntPeriodic { get; set; }
        public string MaximumInactiveDays { get; set; }
        public string ActionForMax_Inactive_Days { get; set; }
        public string User1 { get; set; }
    }
}
