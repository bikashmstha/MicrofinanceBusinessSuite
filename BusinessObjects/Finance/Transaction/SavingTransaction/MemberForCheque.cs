using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.SavingTransaction
{
    public class MemberForCheque : BusinessObject
    {
        public MemberForCheque() { }

        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public string ClientNo { get; set; }
        public double RowCount { get; set; }
    }
}
