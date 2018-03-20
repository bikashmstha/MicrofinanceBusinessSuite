using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class TransferSavingAccount : BusinessObject
    {
        public TransferSavingAccount() { }

        public string FromCenterCode { get; set; }
        public string FromClientNo { get; set; }
        public string FromSavingProduct { get; set; }
        public string FromAccountNo { get; set; }
        public string FromAccountDate { get; set; }
        public string ToCenterCode { get; set; }
        public string ToClientNo { get; set; }
        public string ToSavingProduct { get; set; }
        public string TranOfficeCode { get; set; }
        public string OutSavingAccount_No { get; set; }
    }
}
