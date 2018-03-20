using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanAdditionalLoan : BusinessObject
    {
        public StaffLoanAdditionalLoan() { }

        public string LoanDno { get; set; }
        public string LoanNo { get; set; }
        public string ClientDesc { get; set; }
        public string LoanProductCode { get; set; }
        public string LoanDate { get; set; }
        public string MatureDate { get; set; }
        public double RowCount { get; set; }
    }
}
