using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.SavingTransaction
{
    public class MemberAccountOpen : BusinessObject
    {
        public MemberAccountOpen() { }

        public string AccountNo { get; set; }
        public string SavingAccountNo { get; set; }
        public string ClientName { get; set; }
        public string CenterName { get; set; }
        public string ClientCode { get; set; }
        public double RowCount { get; set; }
    }
}
