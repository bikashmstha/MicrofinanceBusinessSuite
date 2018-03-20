using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.SavingTransaction
{
    public class ProductForAccountClose : BusinessObject
    {
        public ProductForAccountClose() { }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string IntSchemeCode { get; set; }
    }
}
