using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class PublicAccountDetail : BusinessObject
    {
        public PublicAccountDetail() { }

        public string AccountNo { get; set; }
        public string FiscalYear { get; set; }
        public string SavingAccountNo { get; set; }
        public string ClientNo { get; set; }
        public string MemberName { get; set; }
        public string SavingProductCode { get; set; }
        public string AccountOperationType { get; set; }
        public string TransferDepositTo_Ref_Ac { get; set; }
        public double AccClosingCharge { get; set; }
        public string AccountOpenDate { get; set; }
        public string AccountStatus { get; set; }
        public string AccountClosedDate { get; set; }
        public string SavProdDesc { get; set; }
        public string IntSchemeCode { get; set; }
        public double AmtAtMaturity { get; set; }
        public double InterestRate { get; set; }
        public string TransferIntPeriodic { get; set; }
        public string IntSchDesc { get; set; }
        public double CurrentBalance { get; set; }
        public string OpenDateBs { get; set; }
        public double DueMandatoryAmount { get; set; }
        public double FixedCollectAmount { get; set; }
        public int DepositPeriod { get; set; }
        public string CollectionType { get; set; }
        public string ReferenceAccountNo { get; set; }
        public string MaturityDate { get; set; }
        public string ContraAcNo { get; set; }
        public string AccountDesc { get; set; }
        public string ContraAccount { get; set; }
    }
}
