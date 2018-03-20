using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class GoodReceiptEmployee : BusinessObject
    {
        public GoodReceiptEmployee() { }

        public string EmpId { get; set; }
        public string EmpName { get; set; }
    }
}
