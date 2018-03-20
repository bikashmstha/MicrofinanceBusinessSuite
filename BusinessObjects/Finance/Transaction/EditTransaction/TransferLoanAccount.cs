using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class TransferLoanAccount : BusinessObject
    {
        public TransferLoanAccount() { }

        public string FromCenterCode { get; set; }
        public string FromClientNo { get; set; }
        public string FromLoanProduct { get; set; }
        public string FromLoanNo { get; set; }
        public string ToCenterCode { get; set; }
        public string ToClientNo { get; set; }
        public string ToLoanProduct { get; set; }
        public string ToLoanPurpose_Code { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string TranOfficeCode { get; set; }
        public string OutToLoan_No { get; set; }
    }
}
