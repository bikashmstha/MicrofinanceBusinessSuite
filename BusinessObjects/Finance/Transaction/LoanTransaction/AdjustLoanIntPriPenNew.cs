using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class AdjustLoanIntPriPenNew : BusinessObject
    {
        public AdjustLoanIntPriPenNew() { }

        public string LoanNo { get; set; }
        public string RepaymentY_N { get; set; }
        public double? RepaymentNo { get; set; }
        public string PaymentDate { get; set; }
        public double? CollectionSheet_No { get; set; }
        public double? InterestAmt { get; set; }
        public double? PrincipalAmt { get; set; }
        public double? PenaltyAmt { get; set; }
        public double? NewInt_Amt { get; set; }
        public double? NewPri_Amt { get; set; }
        public double? NewPen_Amt { get; set; }
        public string User1 { get; set; }
    }
}
