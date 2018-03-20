using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class PublicReferenceAccount : BusinessObject
    {
        public PublicReferenceAccount() { }

        public string SavingAccountNo { get; set; }
        public string ClientName { get; set; }
        public string SavingProductCode { get; set; }
        public string SavingProductName { get; set; }
        public double CurrentBalance { get; set; }
        public double ReceivedInterestAmount { get; set; }
        public string AccountNo { get; set; }
        public double RowCount { get; set; }
    }
}
