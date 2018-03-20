using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MfLoanSearch : BusinessObject
    {
        public MfLoanSearch() { }

        public string LoanDno { get; set; }
        public string LoanNo { get; set; }
        public string ClientName { get; set; }
        public string CenterName { get; set; }
        public double RowCount { get; set; }
        public string CenterCode { get; set; }
        public string ClientNo { get; set; }
    }
}
