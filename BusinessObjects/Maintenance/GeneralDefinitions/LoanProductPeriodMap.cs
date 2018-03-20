using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Maintenance
{
    public class LoanProductPeriodMap:BusinessObject
    {
        public string LoanPeriod { get; set; }
        public string LoanPeriodType { get; set; }
        public string LoanPeriodTypeDet { get; set; }
        public string LoanProductCode { get; set; }
        public string Description { get; set; }
        public Int64 DisplaySequence { get; set; }
        public string Active { get; set; }
    }
}
