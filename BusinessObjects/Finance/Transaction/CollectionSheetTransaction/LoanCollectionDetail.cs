using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.CollectionSheetTransaction
{
    public class LoanCollectionDetail : BusinessObject
    {
        public LoanCollectionDetail() { }

        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string LoanType { get; set; }
        public string ClientName { get; set; }
        public double TotalLoanAmount { get; set; }
        public double TotalPrincipalOutstanding { get; set; }
        public double PastPrincipalDue { get; set; }
        public double CurrentPrincipalSchedule { get; set; }
        public double PastInterestDue { get; set; }
        public double InterestAmount { get; set; }
        public double PenaltyAmount { get; set; }
        public double PaidAmount { get; set; }
        public double PrincipalPaidAmount { get; set; }
        public double InterestPaidAmount { get; set; }
        public double PenaltyPaidAmount { get; set; }
        public string AdjustFromSaving { get; set; }
        public string SavingAccountNo { get; set; }
        public string Received { get; set; }
        public string ChequeNo { get; set; }
        public string ClientNo { get; set; }
        public string ClientCode { get; set; }
        public double AdjustAmtFrmSaving { get; set; }
        public double TotalInterestAmount { get; set; }
        public string CollectionSheetNo { get; set; }
        public string CollectionDate { get; set; }

        
    }
}
