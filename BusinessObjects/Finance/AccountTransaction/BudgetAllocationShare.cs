using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class BudgetAllocationShare : BusinessObject
    {
        public BudgetAllocationShare() { }

        public string FiscalYear { get; set; }
        public string TranOfficeCode { get; set; }
        public string AccountCode { get; set; }
        public string ReBudgetDate { get; set; }
        public double ReAllocAmt { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string Active { get; set; }
    }
}
