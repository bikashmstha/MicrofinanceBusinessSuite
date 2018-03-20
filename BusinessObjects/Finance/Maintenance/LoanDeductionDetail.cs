using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Maintenance
{
    public class LoanDeductionDetail : BusinessObject
    {
        public LoanDeductionDetail() { }

        public string LoanProductCode { get; set; }
        public string DeductionTypeDesc { get; set; }
        public string AccountCode { get; set; }
        public int AccountNo { get; set; }
        public string AccountDesc { get; set; }
        public string RowId { get; set; }
        public string LoanPeriodType { get; set; }
        public double LoanPeriodLow_Val { get; set; }
        public double LoanPeriodHigh_Val { get; set; }
        public string DeductionType { get; set; }
        public string DeductionTypeCode { get; set; }
        public double DeductionValue { get; set; }
        public string DeductionCriteria { get; set; }
        public string ChoiceDeductY_N { get; set; }
        public int DeductionFromYear { get; set; }
        public string DedTypeDetail { get; set; }
        public string DedCriteria { get; set; }
    }
}
