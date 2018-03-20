using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MeLoanProduct : BusinessObject
    {
        public MeLoanProduct() { }

        public string LoanProduct_Code { get; set; }
        public string LoanProduct_Name { get; set; }
        public double InterestRate { get; set; }
        public double RowCount { get; set; }
    }
}
