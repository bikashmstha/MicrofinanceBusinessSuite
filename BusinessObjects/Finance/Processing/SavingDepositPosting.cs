using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class SavingDepositPosting : BusinessObject
    {
        public SavingDepositPosting() { }

        public string OfficeCode { get; set; }
        public string TransactionDate { get; set; }
        public double DepositNo { get; set; }
        public string User1 { get; set; }
    }
}
