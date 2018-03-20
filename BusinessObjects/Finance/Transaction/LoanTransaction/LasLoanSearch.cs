using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class LasLoanSearch : BusinessObject
    {
        public LasLoanSearch() { }

        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string ClientDesc { get; set; }
        public string ClientCode { get; set; }
        public string ClientNo { get; set; }
        public string LoanProduct_Name { get; set; }
        public string LoanProduct_Code { get; set; }
        public double RowCount { get; set; }
    }
}
