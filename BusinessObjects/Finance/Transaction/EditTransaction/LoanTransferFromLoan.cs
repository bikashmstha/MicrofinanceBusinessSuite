using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class LoanTransferFromLoan : BusinessObject
    {
        public LoanTransferFromLoan() { }

        public string LoanProduct_Code { get; set; }
        public string LoanProduct_Name { get; set; }
        public string LoanDate { get; set; }
        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string LoanDate_Bs { get; set; }
        public double RowCount { get; set; }
    }
}
