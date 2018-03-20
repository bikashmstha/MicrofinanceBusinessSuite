using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class PublicSavingWithdrawl : BusinessObject
    {
        public PublicSavingWithdrawl() { }

        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public double WithdrawalNo { get; set; }
        public string SavingAccountNo { get; set; }
        public string AccountNo { get; set; }
        public double WithdrawAmount { get; set; }
        public string ChequeNo { get; set; }
        public string AccountDesc { get; set; }
        public string PayeeName { get; set; }
        public string FlagForPosting { get; set; }
    }
}
