using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class PublicChequeUpdate : BusinessObject
    {
        public PublicChequeUpdate() { }

        public string OfficeCode { get; set; }
        public string AccountNo { get; set; }
        public string ChequeNo { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }
}
