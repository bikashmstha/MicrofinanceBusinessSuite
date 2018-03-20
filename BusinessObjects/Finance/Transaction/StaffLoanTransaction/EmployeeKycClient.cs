using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class EmployeeKycClient : BusinessObject
    {
        public EmployeeKycClient() { }

        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public double RowCount { get; set; }
    }
}
