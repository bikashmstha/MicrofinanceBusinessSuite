using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class LoanAdjustLoan : BusinessObject
    {
        public LoanAdjustLoan() { }

        public string LoanDate { get; set; }
        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string MemberName { get; set; }
        public string ClientCode { get; set; }
        public string VoucherNo { get; set; }
        public string LoanProduct_Name { get; set; }
        public string LoanProduct_Code { get; set; }
        public string Address { get; set; }
        public string ClientNo { get; set; }
        public string IntCalc_Type { get; set; }
        public double RowCount { get; set; }
    }
}
