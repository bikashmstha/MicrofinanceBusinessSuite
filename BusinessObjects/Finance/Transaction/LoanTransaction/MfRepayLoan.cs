using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MfRepayLoan : BusinessObject
    {
        public MfRepayLoan() { }

        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string MemberName { get; set; }
        public string ClientCode { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string VoucherNo { get; set; }
        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public string LoanProductName { get; set; }
        public string LoanProductCode { get; set; }
        public string Address { get; set; }
        public string ClientNo { get; set; }
        public string IntCalcType { get; set; }
        public double RowCount { get; set; }
    }
}
