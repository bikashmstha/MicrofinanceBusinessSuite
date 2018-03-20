using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class ChequePrint
    {
        public int  NoOfChequePrint { get; set; }
        public long FromChequeNo { get; set; }
        public long ToChequeNo { get; set; }
        public string FromDisplayNo { get; set; }
        public string ToDisplayNo { get; set; }
    }
}
