using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance
{
    public class LoanPurposeProductDetail : BusinessObject
    {
        public LoanPurposeProductDetail() { }

        public int MinLoanAmount { get; set; }
        public int MaxLoanAmount { get; set; }
        public int MinLoanTermMonths { get; set; }
        public int MaxLoanTermMonths { get; set; }
        public int NoOfAccountOpen { get; set; }
        public string LastChangeDate { get; set; }
        public string Active { get; set; }
        public string LoanProductCode { get; set; }
        public string LoanPurposeCode { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int InterestRate { get; set; }
    }
}
