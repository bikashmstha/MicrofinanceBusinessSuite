using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class PublicChequeNo : BusinessObject
    {
        public PublicChequeNo() { }

        public string ChequeNo { get; set; }
        public string DisplayNo { get; set; }
    }
}
