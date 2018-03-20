using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class SavingTransferFromClient : BusinessObject
    {
        public SavingTransferFromClient() { }

        public string ClientNo { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public double RowCount { get; set; }
    }
}
