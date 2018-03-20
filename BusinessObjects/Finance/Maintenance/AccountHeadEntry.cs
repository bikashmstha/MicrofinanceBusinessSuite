using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance
{
    public class AccountHeadEntry : BusinessObject
    {
        public string AccountCode { get; set; }
        public string AccountNo { get; set; }
        public string AccountDesc { get; set; }
        public string ShortName { get; set; }
        public string GroupNo { get; set; }
        public string GroupName { get; set; }       
        public string CategoryInitial { get; set; }
        public string OpeningBal { get; set; }
        public string OpeningType { get; set; }
        public string AccountCodeMaster { get; set; }
        public string ActiveFlag { get; set; }
        public string ReasonForInActive { get; set; }
        public string CashBankOthers { get; set; }
        public string TransactionCurrencyCode { get; set; }
        public string ContraAccountYN { get; set; }
        public string DisplaySeq { get; set; }
        public string ConsolidateYN { get; set; }
        public string TranOfficeCode { get; set; }
        public string LastChangeDate { get; set; }
        public string TransferDate { get; set; }
        public string ThirdPartyDate { get; set; }
       
    }
}
