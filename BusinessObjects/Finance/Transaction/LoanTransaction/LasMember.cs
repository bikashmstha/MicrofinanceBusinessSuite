using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class LasMember : BusinessObject
    {
        public LasMember() { }

        public string ClientCode { get; set; }
        public string ClientNo { get; set; }
        public string Name { get; set; }
        public string SavingAccount_No { get; set; }
        public string AccountNo { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string CenterCode { get; set; }
        public string CenterName { get; set; }
    }
}
