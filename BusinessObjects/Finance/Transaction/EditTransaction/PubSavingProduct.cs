using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class PubSavingProduct : BusinessObject
    {
        public PubSavingProduct() { }

        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductTypeCode { get; set; }
        public string IntSchemeCode { get; set; }
        public string IntSchemeDesc { get; set; }
        public double RowCount { get; set; }
    }
}
