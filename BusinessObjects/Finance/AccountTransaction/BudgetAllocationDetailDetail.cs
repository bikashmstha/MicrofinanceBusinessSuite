using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class BudgetAllocationDetailDetail : BusinessObject
    {
        public BudgetAllocationDetailDetail() { }

        public string FiscalYear { get; set; }
        public string TranOfficeCode { get; set; }
        public string AccountCode { get; set; }
        public double AllocAmt { get; set; }
        public double NetAllocAmt { get; set; }
        public int AccountNo { get; set; }
        public string AccountDesc { get; set; }
    }
}
