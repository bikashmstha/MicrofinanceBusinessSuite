using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MfRepaySearchLoan : BusinessObject
    {
        public MfRepaySearchLoan() { }

        public string CenterCode { get; set; }
        public string ClientNo { get; set; }
        public string LoanDno { get; set; }
        public string LoanNo { get; set; }
        public string ClientName { get; set; }
        public string CenterName { get; set; }
        public double RowCount { get; set; }
    }
}
