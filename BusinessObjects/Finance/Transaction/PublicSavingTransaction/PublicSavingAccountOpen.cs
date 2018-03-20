using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class PublicSavingAccountOpen : BusinessObject
    {
        public PublicSavingAccountOpen() { }

        public string ClientNo { get; set; }
        public string ClientCenter { get; set; }
        public string SavingProductCode { get; set; }
        public string AccountOpenDate { get; set; }
        public string AccountStatus { get; set; }
        public string AccountClosedDate { get; set; }
        public string IntSchemeCode { get; set; }
        public double InterestRate { get; set; }
        public double CurrentBalance { get; set; }
        public string InterestTaxable { get; set; }
        public string SigneeName1 { get; set; }
        public string SigneeName2 { get; set; }
        public string ReasonForClosing { get; set; }
        public double DueMandatoryAmount { get; set; }
        public double AccClosingCharge { get; set; }
        public string TranOfficeCode { get; set; }
        public double FixedCollectAmount { get; set; }
        public string CollectionType { get; set; }
        public double DepositPeriod { get; set; }
        public string DepositPeriodType { get; set; }
        public string ReferenceAccountNo { get; set; }
        public string InsurancePolicyNo { get; set; }
        public double InsurancePolicyAmt { get; set; }
        public double AmtAtMaturity { get; set; }
        public string MaturityDate { get; set; }
        public string AccountOperationType { get; set; }
        public string TransferIntPeriodic { get; set; }
        public string TransferDepositTo_Ref_Ac { get; set; }
        public string ThirdPartyData { get; set; }
        public string User1 { get; set; }
        public string ContraAccount { get; set; }
        public string InsertUpdate { get; set; }
        public string OutFiscalYear { get; set; }
        public string OutPubSav_Ac_No { get; set; }
        public string OutPubSav_Ac_Disp_No { get; set; }
    }
}
