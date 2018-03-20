using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class SavingTransferFromAccount : BusinessObject
    {
        public SavingTransferFromAccount() { }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string AccountOpenDate { get; set; }
        public string AccountNo { get; set; }
        public string SavingAccountNo { get; set; }
        public string AccountOpenDate_Bs { get; set; }
        public double RowCount { get; set; }
    }
}
