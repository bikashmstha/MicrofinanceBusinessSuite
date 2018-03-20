using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MfLoanPurpose : BusinessObject
    {
        public MfLoanPurpose() { }

        public string LoanPurposeCode { get; set; }
        public string LoanPurposeDesc { get; set; }
        public string SubSectorCode { get; set; }
        public string SubSectorDesc { get; set; }
        public double InterestRate { get; set; }
        public double MaxLoanAmount { get; set; }
        public double MinLoanAmount { get; set; }
        public double RowCount { get; set; }
    }
}
