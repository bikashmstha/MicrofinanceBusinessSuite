using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class FundingAgency : BusinessObject
    {
        public FundingAgency() { }

        public int FundingAgency_Code { get; set; }
        public string FundingAgency_Name { get; set; }
    }
}
