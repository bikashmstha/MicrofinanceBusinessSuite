using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class LoanRepayAdjustRepay : BusinessObject
    {
        public LoanRepayAdjustRepay() { }

        public string CollectionSheetNo { get; set; }
        public double RepaymentNo { get; set; }
        public string PaymentDateNep { get; set; }
        public string PaymentDate { get; set; }
        public string LoanDno { get; set; }
        public double TotalReceived { get; set; }
        public double PrincipalReceived { get; set; }
        public double InterestReceived { get; set; }
        public double PenaltyReceived { get; set; }
        public string ChequeNo { get; set; }
        public string SavingAccountDno { get; set; }
        public string AdjustFromSaving { get; set; }
        public string SavingAccountNo { get; set; }
        public string ContraAccount { get; set; }
        public double RowCount { get; set; }
    }
}
