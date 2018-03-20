using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanDisbursementProduct : BusinessObject
    {
        public StaffLoanDisbursementProduct() { }

        public string LoanProductCode { get; set; }
        public string LoanProductName { get; set; }
        public double InterestRate { get; set; }
        public double RowCount { get; set; }
    }
}
