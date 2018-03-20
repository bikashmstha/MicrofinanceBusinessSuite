using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class LoanDisbursementPosting : BusinessObject
    {
        public LoanDisbursementPosting() { }

        public string OfficeCode { get; set; }
        public string TransactionDate { get; set; }
        public string LoanNo { get; set; }
    }
}
