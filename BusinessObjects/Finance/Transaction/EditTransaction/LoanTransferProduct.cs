using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class LoanTransferProduct : BusinessObject
    {
        public LoanTransferProduct() { }

        public string LoanProduct_Code { get; set; }
        public string LoanProduct_Name { get; set; }
        public double RowCount { get; set; }
    }
}
