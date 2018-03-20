using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class PublicAccountCloseProduct : BusinessObject
    {
        public PublicAccountCloseProduct() { }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string IntSchemeCode { get; set; }
        public string ProductClass { get; set; }
        public double RowCount { get; set; }
    }
}
