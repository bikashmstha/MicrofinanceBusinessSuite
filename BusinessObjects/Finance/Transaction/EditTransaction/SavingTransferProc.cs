using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class SavingTransferProc : BusinessObject
    {
        public SavingTransferProc() { }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double RowCount { get; set; }
    }
}
