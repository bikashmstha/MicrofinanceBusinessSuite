using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class LnUtilizationLoan : BusinessObject
    {
        public LnUtilizationLoan() { }

        public string ClientName { get; set; }
        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string LoanDate { get; set; }
        public string LoanDate_Bs { get; set; }
        public double TotalLoan_Amount { get; set; }
        public string LoanPurpose_Code { get; set; }
        public string LoanPurpose { get; set; }
        public string ClientNo { get; set; }
        public string CenterCode { get; set; }
        public double RowCount { get; set; }
    }
}
