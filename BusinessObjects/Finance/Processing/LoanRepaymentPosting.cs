using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class LoanRepaymentPosting : BusinessObject
    {
        public LoanRepaymentPosting() { }

        public string OfficeCode { get; set; }
        public string TransactionDate { get; set; }
        public double RepaymentNo { get; set; }
    }
}
