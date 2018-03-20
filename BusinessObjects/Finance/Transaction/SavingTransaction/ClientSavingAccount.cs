using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.SavingTransaction
{
    public class ClientSavingAccount : BusinessObject
    {
        public ClientSavingAccount() { }

        public string FiscalYear { get; set; }
        public string AccountNo { get; set; }
        public string SavingAccountNo { get; set; }
        public string ClientCenter { get; set; }
        public string ClientNo { get; set; }
        public string CenterCode { get; set; }
        public string SavingProductCode { get; set; }
        public string AccountOpenDate { get; set; }
        public string AccountStatus { get; set; }
        public string AccountClosedDate { get; set; }
        public string IntSchemeCode { get; set; }
        public double CurrentBalance { get; set; }
        public double ReceivedInterestAmount { get; set; }
        public string InterestTaxable { get; set; }
        public string SigneeName1 { get; set; }
        public string SigneeName2 { get; set; }
        public string ReasonForClosing { get; set; }
        public double DueMandatoryAmount { get; set; }
        public double AccClosingCharge { get; set; }
        public string TranOfficeCode { get; set; }
        public string LastChangeDate { get; set; }
        public string TransferDate { get; set; }
        public double FixedCollectAmount { get; set; }
        public int DepositPeriod { get; set; }
        public double InterestRate { get; set; }
        public string FixedCollectionType { get; set; }
        public string ReferenceAccountNo { get; set; }
        public string InsurancePolicyNo { get; set; }
        public double InsurancePolicyAmt { get; set; }
        public string ThirdPartyData { get; set; }
        public string DepositPeriodType { get; set; }
        public double AmtAtMaturity { get; set; }
        public string AccountOperationType { get; set; }
        public string CollectionType { get; set; }
        public string TransferIntPeriodic { get; set; }
        public string TransferDepositToRefAc { get; set; }
        public string MaturityDate { get; set; }
        public string NextCollectionDate { get; set; }
        public string MannualClosingYN { get; set; }
        public string AccountStatusChangeDate { get; set; }
        public int CollectionTypePeriod { get; set; }
        public string MidTermClosingType { get; set; }
        public string PrematuredIntRatio { get; set; }

        public object ContraAccount { get; set; }

        public object EmployeeId { get; set; }

        public string ClientName { get; set; }

        public string CenterName { get; set; }

        public string ClientCode { get; set; }
    }
}
