using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class PublicClient : BusinessObject
    {
        public PublicClient() { }

        public string ClientCode { get; set; }
        public string ClientNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double RowCount { get; set; }
    }
}
