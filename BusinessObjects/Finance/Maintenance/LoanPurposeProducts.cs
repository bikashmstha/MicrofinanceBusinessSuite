using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance
{
    public class LoanPurposeProducts : BusinessObject
    {

        public string LoanProductCode { get; set; }
        public string LoanPurposeDesc { get; set; }
        public string LoanPurposeCode { get; set; }
        
        
        public long InterestRate { get; set; }
        public long MinLoanAmount { get; set; }

        public long MaxLoanAmount { get; set; }

        public long MinLoanTermsMonths { get; set; }
        public long MaxLoanTermsMonths { get; set; }
        public string NoOfAccountOpen { get; set; }
       
        public string Active { get; set; }
       

        

    }
}
