using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class LoanTransferToClient : BusinessObject
    {
        public LoanTransferToClient() { }

        public string ClientNo { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public double RowCount { get; set; }
    }
}
