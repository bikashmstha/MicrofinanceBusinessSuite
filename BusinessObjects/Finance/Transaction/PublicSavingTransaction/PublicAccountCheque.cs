using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class PublicAccountCheque : BusinessObject
    {
        public PublicAccountCheque() { }

        public string DisplayNo { get; set; }
        public string ChequeNo { get; set; }
        public string OldDisplayNo { get; set; }
        public string OldChequeNo { get; set; }
        public double RowCount { get; set; }
    }
}
