using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class LoanRepayAdjustLoan : BusinessObject
    {
        public LoanRepayAdjustLoan() { }

        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string MemberName { get; set; }
        public string ClientCode { get; set; }
        public string TranOffice_Code { get; set; }
        public string VoucherNo { get; set; }
        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public string LoanProduct_Name { get; set; }
        public string LoanProduct_Code { get; set; }
        public string Address { get; set; }
        public string ClientNo { get; set; }
        public string IntCalc_Type { get; set; }
        public double RowCount { get; set; }
    }
}
