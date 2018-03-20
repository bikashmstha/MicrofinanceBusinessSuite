using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class LoanProductDeduction : BusinessObject
    {
        public LoanProductDeduction() { }

        public string LoanProductCode { get; set; }
        public string DeductionTypeCode { get; set; }
        public string AccountCode { get; set; }
        public string DeductionType { get; set; }
        public double DeductionValue { get; set; }
        public string DeductionCriteria { get; set; }
        public double DeductionFromYear { get; set; }
        public string ChoiceDeductY_N { get; set; }
        public string LoanPeriodType { get; set; }
        public double LoanPeriodLow_Val { get; set; }
        public double LoanPeriodHigh_Val { get; set; }
        public string RowId { get; set; }
        public string User1 { get; set; }
    }
}
