using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.SavingTransaction
{
    public class GenerateChequeSequence : BusinessObject
    {
        public GenerateChequeSequence() { }

        public double ToChequeNo { get; set; }
        public string OfficeCode { get; set; }
        public string AccountNo { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public double FromChequeNo { get; set; }
    }
}
