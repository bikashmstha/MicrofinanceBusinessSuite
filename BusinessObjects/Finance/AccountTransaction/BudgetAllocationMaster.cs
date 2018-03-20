using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class BudgetAllocationMaster : BusinessObject
    {
        public BudgetAllocationMaster() { }

        public string FiscalYear { get; set; }
        public string TranOfficeCode { get; set; }
        public string AllocDate { get; set; }
        public string Active { get; set; }
        public string InsertUpdateMst { get; set; }

        public List<BudgetAllocationDetail> BudgetAllocationDetail { get; set; }
    }
}
