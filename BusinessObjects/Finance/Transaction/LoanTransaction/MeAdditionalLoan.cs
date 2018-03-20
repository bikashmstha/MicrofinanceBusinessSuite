using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MeAdditionalLoan : BusinessObject
    {
        public MeAdditionalLoan() { }

        public string LoanDno { get; set; }
        public string LoanNo { get; set; }
        public string ClientDesc { get; set; }
        public string LoanProduct_Code { get; set; }
        public string LoanDate { get; set; }
        public string MatureDate { get; set; }
    }
}
