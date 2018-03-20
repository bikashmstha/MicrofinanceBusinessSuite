using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class BudgetLimitAmt : BusinessObject
    {
        public BudgetLimitAmt() { }

        public double BudgetLimitAmount { get; set; }
    }
}
