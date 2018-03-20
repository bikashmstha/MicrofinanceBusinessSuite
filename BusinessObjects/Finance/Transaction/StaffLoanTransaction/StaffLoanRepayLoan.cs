using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanRepayLoan : BusinessObject
    {
        public StaffLoanRepayLoan() { }

        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string ClientDesc { get; set; }
        public string EmployeeId { get; set; }
        public string ClientCode { get; set; }
        public string ClientNo { get; set; }
        public string LoanProductName { get; set; }
        public string LoanProductCode { get; set; }
        public double RowCount { get; set; }
    }
}
