using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.SavingTransaction
{
    public class ChequeGenerateDetail : BusinessObject
    {
        public ChequeGenerateDetail() { }

        public string Status { get; set; }
        public string ReasonForCancel { get; set; }
        public string StatusValue { get; set; }
        public string PrintedByOn { get; set; }
        public string AccountNo { get; set; }
        public string DisplayNo { get; set; }
        public string ChequeNo { get; set; }
    }
}
