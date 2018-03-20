using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class BudgetAllocationShareDetail : BusinessObject
    {
        public BudgetAllocationShareDetail() { }

        public string AccountCode { get; set; }
        public string ReBudgetDate { get; set; }
        public double ReAllocAmt { get; set; }
    }
}
