using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class PubSavingAccountSearch : BusinessObject
    {
        public PubSavingAccountSearch() { }

        public string AccountNo { get; set; }
        public string SavingAccountNo { get; set; }
        public string ProductCode { get; set; }
        public string ClientDesc { get; set; }
        public string ClientCode { get; set; }
        public string Address { get; set; }
        public string ProductName { get; set; }
        public string ClientNo { get; set; }
        public double FixedCollectAmount { get; set; }
        public double RowCount { get; set; }
    }
}
