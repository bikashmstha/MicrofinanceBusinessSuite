using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class AccountChequeList
    {
        public string DisplayNo { get; set; }

        public string Status { get; set; }

        public string ReasonForCancel { get; set; }

        public string CreatedOn { get; set; }

        public string ChequeNo { get; set; }
    }
}
