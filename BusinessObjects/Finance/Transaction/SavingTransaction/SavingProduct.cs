using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.SavingTransaction
{
    public class SavingProduct : BusinessObject
    {
        public SavingProduct() { }

        public double PenaltyCalcTill { get; set; }
        public string SavingAccountHead { get; set; }
        public string InterestAccountHead { get; set; }
        public string PenaltyAccountHead { get; set; }
        public string ProductStartFrom { get; set; }
        public string ProductValidTill { get; set; }
        public double TdsInterestPercentage { get; set; }
        public double IntCalcPeriod { get; set; }
        public string Compulsory { get; set; }
        public double MinAccountOpenAmount { get; set; }
        public double AccountClosingCharge { get; set; }
        public string AccCloseIfLoanExists { get; set; }
        public string ClosingChargeAccHead { get; set; }
        public string TaxOnIntAccHead { get; set; }
        public string FixedCollectionDay { get; set; }
        public double PrematuredIntRatio { get; set; }
        public double InterestTaxableLimit { get; set; }
        public string InterestTaxable { get; set; }
        public double MinTermIntRate { get; set; }
        public string ThirdPartyData { get; set; }
        public string ReferenceAccountYN { get; set; }
        public double PreCashDeductionOrder { get; set; }
        public string Active { get; set; }
        public string Description { get; set; }
        public double NoOfAccountOpen { get; set; }
        public string AccClosedIfClientActive { get; set; }
        public string OtherIncomeAcHead { get; set; }
        public string OtherExpenseAcHead { get; set; }
        public string IntCapitalized { get; set; }
        public string SavingProductFor { get; set; }
        public double CompulsoryAmount { get; set; }
        public string MidTermClosingType { get; set; }
        public string LedgerReportName { get; set; }
        public string RegisterReportName { get; set; }
        public string InterestPayableReportName { get; set; }
        public string ChargeIncomeAccountHead { get; set; }
        public string ClosedAcLedgerReportName { get; set; }
        public string PayUnpostInterestYN { get; set; }
        public string MannualClosingYN { get; set; }
        public double NoOfChequePrint { get; set; }
        public string TotalDepositPeriodType { get; set; }
        public double TotalDepositPeriod { get; set; }
        public string ReferenceSavingProductCode { get; set; }
        public string TransferIntPeriodic { get; set; }
        public double MaximumInactiveDays { get; set; }
        public string ActionForMaxInactiveDays { get; set; }
        public string RecalculateMidtermInt { get; set; }
        public string AccurateIntAcHead { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductPrefix { get; set; }
        public string ProductTypeCode { get; set; }
        public string IntSchemeCode { get; set; }
        public string IntCalcMethod { get; set; }
        public double MinBalance { get; set; }
        public double MinInterestBalance { get; set; }
        public double MaxWithdrawAmount { get; set; }
        public double LessInterestPrematureEnd { get; set; }
        public string PeriodType { get; set; }
        public double InstallmentPeriod { get; set; }
        public double PenaltyLateInstallment { get; set; }
        public double GraceDaysPenalty { get; set; }
        public string IntSchemeDesc { get; set; }


        public string ProductTypeDesc { get; set; }

        public string ProductClass { get; set; }
    }
}
