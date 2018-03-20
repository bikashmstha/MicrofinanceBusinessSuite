using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class SavingWithdrawlPosting : BusinessObject
    {
        public SavingWithdrawlPosting() { }

        public string OfficeCode { get; set; }
        public string TransactionDate { get; set; }
        public double WithdrawalNo { get; set; }
        public string User1 { get; set; }
    }
}
