using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanDisbursementLoan : BusinessObject
    {
        public StaffLoanDisbursementLoan() { }

        public string ClientNo { get; set; }
        public string LoanDno { get; set; }
        public string LoanNo { get; set; }
        public string ClientName { get; set; }
        public double RowCount { get; set; }
    }
}
