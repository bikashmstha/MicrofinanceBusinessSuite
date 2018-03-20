using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.CollectionSheetTransaction
{
    public class CollectionAdjust : BusinessObject
    {
        public CollectionAdjust() { }

        public string AccountNo { get; set; }
        public string SavingAccountNo { get; set; }
        public string ProductName { get; set; }
    }
}
