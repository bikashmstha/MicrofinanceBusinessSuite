using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class LoanLasSavingProduct : BusinessObject
    {
        public LoanLasSavingProduct() { }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductType_Code { get; set; }
        public double RowCount { get; set; }
    }
}
