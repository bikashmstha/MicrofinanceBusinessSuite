using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class SavingTransferFromCenter : BusinessObject
    {
        public SavingTransferFromCenter() { }

        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public double RowCount { get; set; }
    }
}
