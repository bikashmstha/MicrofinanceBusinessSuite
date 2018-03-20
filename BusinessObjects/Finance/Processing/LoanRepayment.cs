using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class LoanRepayment : BusinessObject
    {
        public LoanRepayment() { }

        public string LoanNo { get; set; }
        public string MemberName { get; set; }
        public string LoanDno { get; set; }
        public double PaidAmount { get; set; }
        public double PrincipalPaidAmount { get; set; }
        public double InterestPaidAmount { get; set; }
        public double PenaltyPaidAmount { get; set; }
        public string SavAcNo { get; set; }
        public string ContraAcDesc { get; set; }
        public string ChequeNo { get; set; }
        public double RepaymentNo { get; set; }
    }
}
