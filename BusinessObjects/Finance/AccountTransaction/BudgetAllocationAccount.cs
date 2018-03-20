using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class BudgetAllocationAccount : BusinessObject
    {
        public BudgetAllocationAccount() { }

        public string AccountCode { get; set; }
        public int AccountNo { get; set; }
        public string AccountDesc { get; set; }
        public double RowCount { get; set; }
    }
}
